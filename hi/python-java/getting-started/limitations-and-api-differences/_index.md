---
title: सीमाएँ और API अंतर
type: docs
weight: 100
url: /hi/python-java/limitations-and-api-differences/
keywords: "नोड, पावरपॉइंट, सीमाएँ, एपीआई, अंतर"
description: "Aspose.Slides for Python via Java की सीमाएँ और API अंतर।"
---
## **ज्ञात बग/सीमाएँ**
Java क्लासेज़ जो पैकेज के बाहर ( `default` ) होते हैं, उन्हें आयात नहीं किया जा सकता।  
JVM समर्थन की कमी के कारण, आप JVM को शटडाउन करके फिर से शुरू नहीं कर सकते। तथा आप JVM की एक से अधिक प्रतियों को शुरू नहीं कर सकते।  
64 बिट Python को 32 बिट Java के साथ या उसके विपरीत मिलाने पर jpype मॉड्यूल को आयात करने पर क्रैश होता है।

## **सार्वजनिक API अंतर**
निम्नलिखित सूची (नमूना कोड सेगमेंट्स के साथ) Aspose.Slides for Java और Aspose.Slides for Python via Java API के बीच कुछ अंतर दर्शाती है।

### **लाइब्रेरी आयात करना (पैकेज तुलना)**

**Aspose.Slides for Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

jpype.shutdownJVM()

```

### **एक नया प्रस्तुतीकरण बनाना**

**Aspose.Slides for Java**

```java
Presentation pres = new Presentation();
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation

pres = Presentation();

jpype.shutdownJVM()
```

### **फ़ाइलों और स्थिरांकों को स्ट्रीमिंग करना**

**Aspose.Slides for Java**

```java
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input = open("presentation.pptx", mode="rb")
data = input.read()
pres = Presentation.createPresentationFromBytes(data)
pres.save("result.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```

### **Aspose.Slides for Python via Java API की Aspose.Slides for Java API की तुलना में अन्य सीमाएँ**

अन्य सीमाओं के बारे में अधिक जानकारी के लिए, कृपया jpype दस्तावेज़ देखें: 
- https://jpype.readthedocs.io/en/latest/