---
title: प्रस्तुतियों में Python के साथ वीडियो फ्रेम प्रबंधन
linktitle: वीडियो फ्रेम
type: docs
weight: 10
url: /hi/python-net/video-frame/
keywords:
- वीडियो जोड़ें
- वीडियो बनाएँ
- वीडियो एम्बेड करें
- वीडियो निकालेँ
- वीडियो पुनः प्राप्त करें
- वीडियो फ्रेम
- वेब स्रोत
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument स्लाइड्स में प्रोग्रामेटिक रूप से वीडियो फ्रेम जोड़ने और निकालने के बारे में जानें। तेज़ कैसे-करें मार्गदर्शिका।"
---
## **परिचय**

वीडियो विचारों को समझाने और दर्शकों को आकर्षित करने में मदद कर सकते हैं। Aspose.Slides for Python via .NET आपको स्लाइड्स में वीडियो फ्रेम जोड़ने, प्लेबैक सेटिंग्स समायोजित करने, कैप्शन प्रबंधित करने, और एम्बेडेड वीडियो डेटा निकालने की सुविधा देता है।

PowerPoint स्थानीय वीडियो और ऑनलाइन वीडियो के लिंक, जैसे YouTube वीडियो, को समर्थन देता है।

वीडियो डेटा और वीडियो फ्रेम को दर्शाने के लिए, Aspose.Slides [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) क्लास, [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) क्लास, और अन्य संबंधित प्रकार प्रदान करता है।

## **एक एम्बेडेड वीडियो फ्रेम बनाएं**

यदि वह वीडियो फ़ाइल जिसे आप अपनी स्लाइड में जोड़ना चाहते हैं स्थानीय रूप से संग्रहीत है, तो आप अपनी प्रस्तुति में वीडियो को एम्बेड करने के लिए एक वीडियो फ्रेम बना सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर एक स्थानीय वीडियो को एम्बेड करता है और परिणाम को सहेजता है। फ्रेम के निर्देशांक और आयाम पॉइंट्स में होते हैं। स्ट्रीम तब तक खुला रहता है जब तक सहेजा नहीं जाता क्योंकि [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) प्रस्तुति द्वारा उपयोग किए जाने पर इसे लॉक रखता है।

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

आप स्थानीय वीडियो पथ को सीधे [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/) को भी पास कर सकते हैं। यह उदाहरण नई प्रस्तुति की पहली स्लाइड पर वीडियो को एम्बेड करता है। प्रस्तुति सहेजे जाने तक वीडियो तक पहुंच योग्य रहना आवश्यक है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **वेब स्रोत से वीडियो के साथ एक वीडियो फ्रेम बनाएं**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) प्रस्तुतियों में ऑनलाइन वीडियो को समर्थन देता है। आप एक वीडियो फ्रेम बना सकते हैं जो ऑनलाइन वीडियो, जैसे YouTube वीडियो, से लिंक करता है।

यह उदाहरण पहली स्लाइड में एक YouTube वीडियो लिंक और थंबनेल जोड़ता है। किसी अन्य वीडियो का उपयोग करने के लिए वीडियो पहचानकर्ता को बदलें। [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) सेटिंग स्वचालित प्लेबैक का अनुरोध करती है। थंबनेल डाउनलोड करने और वीडियो चलाने के लिए इंटरनेट एक्सेस आवश्यक है। प्रस्तुति दर्शक को भी ऑनलाइन वीडियो प्लेबैक को समर्थन देना चाहिए।

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **पूरा-स्क्रीन मोड में वीडियो चलाएँ**

एक प्रशिक्षण प्रस्तुति में, आप सॉफ्टवेयर डेमोंस्ट्रेशन को पूरा-स्क्रीन मोड में चला सकते हैं ताकि दर्शक विवरण देख सकें। प्लेबैक के दौरान यह व्यवहार सक्षम करने के लिए [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) को `True` सेट करें।

यह उदाहरण एक प्रस्तुति खोलता है, पहली स्लाइड पर पहला [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) खोजता है, और पूरा-स्क्रीन प्लेबैक को सक्षम करता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड होनी चाहिए जिसमें पहली स्लाइड पर मौजूदा वीडियो फ्रेम हो।

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

पूरा-स्क्रीन प्लेबैक यह नियंत्रित करता है कि वीडियो कैसे प्रदर्शित किया जाता है। स्वतंत्र रूप से, [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) यह नियंत्रित करता है कि यह स्वचालित रूप से या क्लिक पर शुरू हो, और [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) यह नियंत्रित करता है कि यह दोहराए या नहीं। शुरूआती व्यवहार चुनने के लिए, प्लेबैक मोड को [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) पर सेट करें। उदाहरण मौजूदा शुरूआती और लूप सेटिंग्स को बनाए रखता है।

## **प्लेबैक के बाद वीडियो को रीवाइंड करें**

एक प्रशिक्षण प्रस्तुति में, डेमोंस्ट्रेशन वीडियो को उसकी शुरुआत में लौटाना इसे प्रस्तुतकर्ता द्वारा फिर से चलाने के लिए तैयार करता है। प्लेबैक समाप्त होने के बाद वीडियो को शुरुआत में लौटाने के लिए [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) को `True` सेट करें।

यह उदाहरण एक प्रस्तुति खोलता है, पहली स्लाइड पर पहला [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) खोजता है, और रीवाइंडिंग को सक्षम करता है। यह लूपिंग को निष्क्रिय करता है ताकि प्लेबैक समाप्त हो सके और प्लेबैक को क्लिक पर शुरू होने के लिए सेट करता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड होनी चाहिए जिसमें पहली स्लाइड पर मौजूदा वीडियो फ्रेम हो।

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

रीवाइंडिंग वीडियो को फिर से शुरू किए बिना उसकी शुरुआत में वापस ले जाता है। इसके विपरीत, [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) को सक्षम करने से प्लेबैक स्वचालित रूप से दोहराया जाता है। जब आप चाहते हैं कि वीडियो समाप्त हो और फिर से चलाने के लिए तैयार रहे तो लूपिंग को निष्क्रिय रखें। [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) स्वतंत्र रूप से स्वचालित या क्लिक पर शुरूआत को नियंत्रित करता है; यह उदाहरण [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) का उपयोग करता है ताकि प्रस्तुतकर्ता यह नियंत्रित कर सके कि प्लेबैक कब शुरू हो। उदाहरण में दिखाए अनुसार लूप सेटिंग के बाद प्लेबैक मोड सेट करें। रीवाइंडिंग [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) से स्वतंत्र रूप से कार्य करता है।

## **वीडियो फ्रेम को ट्रिम करें**

[VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) और [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) का उपयोग करके प्लेबैक के दौरान वीडियो की शुरुआत या अंत के भाग को छोड़ सकते हैं। दोनों मान मिलीसेकंड में होते हैं। ट्रिमिंग एम्बेडेड वीडियो डेटा को बदले बिना प्लेबैक सेटिंग्स को बदलता है।

**ट्रिम सेटिंग्स सेट करें**

यह उदाहरण स्थानीय वीडियो को एम्बेड करता है और प्लेबैक के दौरान पहले 2.5 सेकंड और अंतिम सेकंड को छोड़ देता है। एक प्लेबिल सेगमेंट बचाने के लिए 3.5 सेकंड से अधिक लंबा वीडियो उपयोग करें।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**ट्रिम सेटिंग्स पढ़ें**

यह उदाहरण पहली स्लाइड पर पहले वीडियो फ्रेम के ट्रिम मानों को मिलीसेकंड में प्रिंट करता है। प्रस्तुति में कम से कम एक स्लाइड होनी चाहिए। यदि उस स्लाइड में वीडियो फ्रेम नहीं है, तो कुछ नहीं प्रिंट होता। पिछले उदाहरण ने 2500 और 1000 मान उत्पन्न किए।

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **वीडियो कैप्शन प्रबंधन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ्रेम के क्लोज्ड कैप्शन प्रबंधित करने की अनुमति देता है। कैप्शन WebVTT फ़ॉर्मेट में संग्रहीत होते हैं और [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) प्रॉपर्टी के माध्यम से उपलब्ध होते हैं।

### **वीडियो फ्रेम में कैप्शन जोड़ें**

यह उदाहरण स्थानीय वीडियो को एम्बेड करता है और English लेबल वाली एक WebVTT कैप्शन ट्रैक जोड़ता है। कैप्शन टाइमस्टैम्प वीडियो से मेल खाने चाहिए। सहेजी गई प्रस्तुति में वीडियो और उसके कैप्शन दोनों शामिल हैं।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

[CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) क्लास एक ओवरलोड भी प्रदान करती है जो आपको स्ट्रीम से कैप्शन जोड़ने की सुविधा देता है।

### **वीडियो फ्रेम से कैप्शन निकालें**

यह उदाहरण पहली स्लाइड पर वीडियो फ्रेमों के सभी कैप्शन ट्रैक को अलग-अलग WebVTT फ़ाइलों के रूप में सहेजता है। क्रमिक संख्या आउटपुट फ़ाइलों को अलग रखती हैं। कंसोल निकाले गए ट्रैक की संख्या रिपोर्ट करता है। प्रस्तुति में कम से कम एक स्लाइड होनी चाहिए।

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

प्रत्येक [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और कैप्शन टेक्स्ट को UTF-8 स्ट्रिंग के रूप में प्रदर्शित करता है।

### **वीडियो फ्रेम से कैप्शन हटाएँ**

यह उदाहरण पहली स्लाइड पर पहली शेप स्थिति में स्थित वीडियो फ्रेम से सभी कैप्शन हटाता है और परिणाम सहेजता है। यह मानता है कि स्लाइड और शेप मौजूद हैं और शेप एक वीडियो फ्रेम है।

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

यदि आपको केवल एक कैप्शन ट्रैक हटाना है, तो [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) के बजाय [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) या [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) मेथड्स का उपयोग करें।

### **वीडियो कैप्शन खोजें**

[Captions.data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) पूरे WebVTT ट्रैक को लौटाता है, जिसमें इसका हेडर, टाइमिंग लाइनें, और कैप्शन टेक्स्ट शामिल हैं। उदाहरण के लिए, स्लाइड 2 पर एक English ट्रैक में यह क्यु हो सकता है:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

यह उदाहरण `captioned_media.pptx` खोलता है और प्रत्येक स्लाइड पर प्रत्येक टॉप-लेवल वीडियो फ्रेम के [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) को पढ़ता है। प्रत्येक प्लेन-टेक्स्ट क्यु के लिए, यह `-->` वाली टाइमिंग लाइन को खोजता है और अगले खाली लाइन या ट्रैक के अंत तक के कैप्शन लाइनों को एकत्र करता है। यह कैप्शन टेक्स्ट में "café" को केस के बिना खोजता है और प्रत्येक मिलान के लिए स्लाइड नंबर, ट्रैक लेबल, मूल टाइमिंग लाइन, और पूर्ण कैप्शन प्रिंट करता है।

```python
import aspose.slides as slides

with slides.Presentation("captioned_media.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.VideoFrame):
                continue

            for track in shape.caption_tracks:
                lines = iter(track.data_as_string.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue

                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)

                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.slide_number} | {track.label} | {timing}")
                        print(caption)
```

उदाहरण ट्रैक एक मिलान उत्पन्न करता है। हेडर में "Café" कैप्शन टेक्स्ट के बाहर है, और आउटपुट टाइमिंग सेटिंग और दोनों कैप्शन लाइनों को बरकरार रखता है।

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **स्लाइड से वीडियो निकालें**

स्लाइड में वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एम्बेडेड वीडियो निकालने की सुविधा देता है।

यह उदाहरण हर स्लाइड से एम्बेडेड वीडियो को अलग-अलग, क्रमांकित बाइनरी फ़ाइलों में निकालता है। लिंक्ड वीडियो को छोड़ा जाता है क्योंकि उनके पास एम्बेडेड डेटा नहीं होता। कंसोल प्रत्येक वीडियो का MIME टाइप और कुल संख्या प्रिंट करता है। आउटपुट सामान्य `.bin` एक्सटेंशन का उपयोग करता है; आवश्यकता अनुसार इसे रिपोर्टेड मीडिया टाइप से मेल कराने के लिए बदलें।

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **अक्सर पूछे जाने वाले प्रश्न**

**किस वीडियो फ्रेम के लिए कौन सी वीडियो प्लेबैक पैरामीटर बदले जा सकते हैं?**

आप [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (auto या on click) और [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) ऑब्जेक्ट की प्रॉपर्टीज़ के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल आकार प्रभावित होता है?**

हां। जब आप एक स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल आकार के अनुपात में बढ़ता है। जब आप ऑनलाइन वीडियो को लिंक करते हैं और थंबनेल जोड़ते हैं, तो प्रस्तुति लिंक और प्रीव्यू इमेज को वीडियो डेटा के बजाय संग्रहीत करती है, इसलिए आकार वृद्धि आमतौर पर कम होती है।

**क्या मैं मौजूदा वीडियो फ्रेम में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूं?**

हां। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) को बदल सकते हैं जबकि आकारविज़ के ज्यामिति को संरक्षित रखते हैं; यह मौजूदा लेआउट में मीडिया अपडेट करने का सामान्य परिदृश्य है।

**क्या एम्बेडेड वीडियो का कंटेंट टाइप (MIME) निर्धारित किया जा सकता है?**

हां। एक एम्बेडेड वीडियो के पास एक [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) होता है जिसे आप पढ़ सकते हैं और उपयोग कर सकते हैं, उदाहरण के लिए जब आप इसे डिस्क पर सहेजते हैं।