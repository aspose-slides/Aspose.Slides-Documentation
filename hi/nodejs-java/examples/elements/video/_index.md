---
title: वीडियो
type: docs
weight: 80
url: /hi/nodejs-java/examples/elements/video/
keywords:
- कोड उदाहरण
- वीडियो
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ वीडियो जोड़ें और नियंत्रित करें: सम्मिलित करें, चलाएँ, ट्रिम करें, पोस्टर फ़्रेम सेट करें, और PPT, PPTX और ODP प्रस्तुतियों के उदाहरणों के साथ निर्यात करें।"
---
यह लेख दर्शाता है कि **Aspose.Slides for Node.js via Java** का उपयोग करके वीडियो फ़्रेम को एम्बेड कैसे करें और प्लेबैक विकल्प सेट करें।

## **वीडियो फ़्रेम जोड़ें**

स्लाइड में एक वीडियो फ़्रेम जोड़ें।

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // वीडियो जोड़ें।
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **वीडियो फ़्रेम तक पहुँचें**

स्लाइड में जोड़ा गया पहला वीडियो फ़्रेम प्राप्त करें।

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // स्लाइड पर पहला वीडियो फ़्रेम तक पहुँचें।
        let firstVideo = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IVideoFrame")) {
                firstVideo = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **वीडियो फ़्रेम हटाएँ**

स्लाइड से एक वीडियो फ़्रेम हटाएँ।

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // मान लें कि पहली आकृति वीडियो फ़्रेम है।
        let videoFrame = slide.getShapes().get_Item(0);

        // वीडियो फ़्रेम हटाएँ।
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **वीडियो प्लेबैक सेट करें**

स्लाइड प्रदर्शित होने पर वीडियो को स्वचालित रूप से चलाने के लिए कॉन्फ़िगर करें।

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // मान लें कि पहली आकृति वीडियो फ़्रेम है।
        let videoFrame = slide.getShapes().get_Item(0);

        // वीडियो को स्वचालित रूप से चलाने के लिए कॉन्फ़िगर करें।
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```