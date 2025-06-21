mergeInto(LibraryManager.library, {
  SendToFlutter: function (message) {
    // Call Flutter's JavaScript channel
    window.Flutter.postMessage(UTF8ToString(message));
  }
});