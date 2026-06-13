---
title: ऑडियो
type: docs
weight: 70
url: /hi/nodejs-java/examples/elements/audio/
keywords:
- कोड उदाहरण
- ऑडियो
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ऑडियो उदाहरणों की खोज करें: PPT, PPTX, और ODP प्रस्तुतियों में ध्वनि डालें, चलाएँ, ट्रिम करें और निकालें, स्पष्ट JavaScript कोड के साथ।"
---
यह लेख प्रदर्शित करता है कि कैसे ऑडियो फ्रेम को एम्बेड किया जाए और **Aspose.Slides for Node.js via Java** के साथ प्लेबैक को नियंत्रित किया जाए। निम्नलिखित उदाहरण बुनियादी ऑडियो संचालन दिखाते हैं।

## **ऑडियो फ्रेम जोड़ें**

निम्नलिखित कोड उदाहरण प्रस्तुति स्लाइड पर एक ऑडियो फ्रेम जोड़ता है।

```js
function addAudio() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let audioData = java.newInstanceSync(
            "java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));

        let audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioData);

        presentation.save("audio.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **ऑडियो फ्रेम तक पहुंचें**

यह कोड स्लाइड पर पहला ऑडियो फ्रेम प्राप्त करता है।

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // स्लाइड पर पहला ऑडियो फ़्रेम एक्सेस करें।
        let firstAudio = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAudioFrame")) {
                firstAudio = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ऑडियो फ्रेम हटाएं**

पहले जोड़े गए ऑडियो फ्रेम को हटाएँ।

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // मान लेते हैं कि पहला आकार ऑडियो फ्रेम है।
        let audioFrame = slide.getShapes().get_Item(0);

        // ऑडियो फ्रेम को हटाएँ।
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **ऑडियो प्लेबैक सेट करें**

स्लाइड प्रदर्शित होने पर ऑडियो फ्रेम को स्वचालित रूप से चलाने के लिए कॉन्फ़िगर करें।

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // मान लें कि पहला आकार एक ऑडियो फ्रेम है।
        let audioFrame = slide.getShapes().get_Item(0);

        // स्लाइड दिखाई देने पर स्वचालित रूप से चलाएँ।
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```