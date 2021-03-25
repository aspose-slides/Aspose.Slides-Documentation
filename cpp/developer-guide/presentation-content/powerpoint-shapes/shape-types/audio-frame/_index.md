---
title: Audio Frame
type: docs
weight: 10
url: /cpp/audio-frame/
---

## **Create Audio Frame**
Aspose.Slides for C++ allows developers to add audio files in their slides. These audio files are embedded in the slides as Audio Frames . An Audio Frame contains the embedded audio file. In this topic, we will discuss that how can developers embed audio frames in their slides using Aspose.Slides for C++ . To add an Embedded Audio Frame in a slide using Aspose.Slides for C++ , please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/)
- Obtain the reference of a slide by using its Index
- Open the Audio File Stream to be embedded in the slide
- Add the Embedded Audio Frame (containing audio file) into the slide
- Set [PlayMode](http://www.aspose.com/api/net/slides/aspose.slides/audioplaymodepreset) and Volume exposed by [IAudioFrame](http://www.aspose.com/api/net/slides/aspose.slides/audioframe) object
- Write the modified presentation as a PPTX file

In the example given below, we have added an Embedded Audio Frame into the slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddAudioFrame-AddAudioFrame.cpp" >}}