---
title: Docker में Aspose.Slides चलाने का तरीका
linktitle: Docker में Aspose.Slides
type: docs
weight: 150
url: /hi/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker में Aspose.Slides
- Docker कंटेनर
- Docker फ़ाइल
- Linux
- libgdiplus
- ICU
- OpenSSL
- फ़ॉन्ट्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Docker में .NET के माध्यम से Python के लिए Aspose.Slides चलाएँ: एक कार्यशील Docker फ़ाइल, पैकेज को आवश्यक मूल लाइब्रेरियाँ, फ़ॉन्ट सेटअप, और कंटेनर के भीतर लाइसेंसिंग।"
---
## **अवलोकन**

Aspose.Slides for Python via .NET Linux कंटेनरों में चलता है, लेकिन यह पैकेज एक Python रैपर है जो बंडल किए गए .NET Core 3.1 रनटाइम के चारों ओर स्थित है। उस रनटाइम को तीन नेटिव लाइब्रेरीज की आवश्यकता होती है जो स्लिम Python इमेजों में नहीं आतीं, और यह उनके संस्करणों के प्रति विशेष रूप से संवेदनशील है। यह लेख एक कार्यशील Dockerfile प्रदान करता है, प्रत्येक निर्भरता के मौजूद रहने का कारण बताता है, और फ़ॉन्ट्स व लाइसेंस कैसे जोड़ें दिखाता है।

## **काम करने वाला Dockerfile**

```dockerfile
FROM python:3.11-slim-bullseye

RUN apt-get update && apt-get install -y --no-install-recommends \
        libgdiplus \
        libicu67 \
        libfontconfig1 \
        fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*

RUN pip install --no-cache-dir aspose.slides

WORKDIR /app
COPY app.py .
CMD ["python", "app.py"]
```

`app.py`:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    shape.text_frame.text = "Created inside a Docker container"
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)
```

Build and run:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **बेस इमेज Debian 11 क्यों है**

`aspose.slides` व्हील एक **.NET Core 3.1** रनटाइम बंडल करता है, और वह रनटाइम वर्तमान Debian संस्करणों द्वारा उपलब्ध कराई गई लाइब्रेरी संस्करणों से पुराना है। Debian 12 और 13 पर कंटेनर सफलतापूर्वक बनता है लेकिन पहले `Presentation()` कॉल पर विफल हो जाता है:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

संदेश ग़लत है — इन इमेजों पर ICU *स्थापित* है, लेकिन वह ICU 72 या 76 है, और .NET Core 3.1 केवल पुराने प्रमुख संस्करणों को पहचानता है। Debian 12 अतिरिक्त रूप से OpenSSL 3 लाता है, जिससे दूसरा विफलता उत्पन्न होता है:

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` Debian 11 है, जो बंडल किए गए रनटाइम द्वारा अपेक्षित दोनों संस्करण प्रदान करता है:

| पैकेज | Debian 11 पर संस्करण | यह क्यों आवश्यक है |
|---|---|---|
| `libgdiplus` | 6.0.4 | आकृतियों, टेक्स्ट और चित्रों को रेंडर करने के लिए उपयोग किया गया GDI+ कार्यान्वयन |
| `libicu67` | 67.1 | वैश्वीकरण डेटा। नवीनतम प्रमुख संस्करण .NET Core 3.1 द्वारा पहचाने नहीं जाते |
| `libssl1.1` | 1.1.1w | क्रिप्टोग्राफी। Debian 11 पर पहले से इंस्टॉल है; Debian 12+ में अनुपलब्ध |
| `libfontconfig1` | — | फ़ॉन्ट खोज |

`libssl1.1` बेस इमेज में पहले से मौजूद है, इसलिए इसे `apt-get install` में सूचीबद्ध करने की आवश्यकता नहीं है।

यदि आपको नया बेस इमेज उपयोग करना आवश्यक है, तो `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1` सेट करके ICU आवश्यकता को बायपास करें। इससे संस्कृति-विशिष्ट फ़ॉर्मेटिंग बंद हो जाती है और यह OpenSSL समस्या का समाधान **नहीं** करता, इसलिए Debian 11 सरल विकल्प बना रहता है।

## **फ़ॉन्ट्स**

स्लिम इमेजों में कोई फ़ॉन्ट नहीं होते। यदि कम से कम एक फ़ॉन्ट स्थापित नहीं है, तो PDF, इमेज और HTML आउटपुट में टेक्स्ट खाली बॉक्सों के रूप में रेंडर होता है। `fonts-dejavu-core` एक छोटा सामान्य-उद्देश्य प्रारंभिक बिंदु है।

एक प्रस्तुति की इच्छित दिखावट से मेल करने के लिए, उसकी उपयोग की गई फ़ॉन्ट्स को इमेज में कॉपी करें और Aspose.Slides को उन पर निर्देशित करें:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **कंटेनर के भीतर लाइसेंसिंग**

लाइसेंस फ़ाइल को इमेज में बनाकर शामिल न करें — इमेज को खींचने वाला कोई भी व्यक्ति लाइसेंस प्राप्त कर लेगा। इसके बजाय इसे रन टाइम पर माउंट करें:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

बिना लाइसेंस के लाइब्रेरी इवैल्यूएशन मोड में चलता है, जो वॉटरमार्क जोड़ता है और प्रक्रिया की गई स्लाइड्स की संख्या को सीमित करता है। विवरण के लिए देखें [लाइसेंसिंग](/slides/hi/python-net/licensing/)।

## **मेमोरी**

PDF या इमेज में रेंडरिंग करना फ़ाइल पढ़ने से अधिक मेमोरी-भारी है। सीमित मेमोरी वाले कंटेनर को OOM किलर द्वारा रूपांतरण के दौरान समाप्त किया जा सकता है, जिससे प्रक्रिया बिना Python ट्रेसबैक के गायब हो जाती है। यदि ऐसा हो, तो कोड की जाँच से पहले कंटेनर की मेमोरी सीमा बढ़ाएँ।