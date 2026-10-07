---
title: Aspose.Slides for Android via Java
second_title: Aspose.Slides for Android
type: docs
weight: 40
url: /hi/androidjava/
keywords:
- दस्तावेज़ीकरण
- प्रस्तुति प्रसंस्करण
- प्रस्तुति रूपांतरण
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "यहाँ से शुरू करें: अपने ऐप में Aspose.Slides for Android via Java जोड़ें, पहली प्रस्तुति बनाएं, और सामान्य कार्यों के मार्गदर्शन, API संदर्भ और समर्थन खोजें."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java एक क्लास लाइब्रेरी है जो Android एप्लिकेशन में PowerPoint और OpenDocument प्रस्तुतियों को बनाने, पढ़ने, संपादित करने और परिवर्तित करने के लिए उपयोग की जाती है, बिना Microsoft PowerPoint के।

यह PPT, PPTX, PPS, POT और ODP फ़ाइलें लोड और सेव करता है, जिसमें मैक्रो‑सक्षम और टेम्प्लेट वैरिएंट शामिल हैं, और PDF, XPS, HTML, SVG, TIFF, Markdown और छवियों में निर्यात करता है।

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>शुरू करें</b></p>
<hr>
<p>शुरूआत</p>
<ul>
<li><a href="/slides/hi/androidjava/install-aspose-slides-for-android-via-java/">स्थापना</a></li>
<li><a href="/slides/hi/androidjava/create-presentation/">पहली प्रस्तुति बनाएं</a></li>
<li><a href="/slides/hi/androidjava/getting-started/">शुरूआत गाइड</a></li>
</ul>
<p>मूल्यांकन</p>
<ul>
<li><a href="/slides/hi/androidjava/supported-file-formats/">समर्थित फ़ाइल फ़ॉर्मेट</a></li>
<li><a href="/slides/hi/androidjava/evaluate-aspose-slides/">ट्रायल प्रतिबंध</a></li>
<li><a href="/slides/hi/androidjava/licensing/">लाइसेंसिंग</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>स्लाइड्स के साथ बनाएं</b></p>
<hr>
<p>सामान्य कार्य</p>
<ul>
<li><a href="/slides/hi/androidjava/open-presentation/">प्रस्तुति खोलें</a></li>
<li><a href="/slides/hi/androidjava/save-presentation/">प्रस्तुति सहेजें</a></li>
<li><a href="/slides/hi/androidjava/convert-powerpoint-to-pdf/">PDF में परिवर्तित करें</a></li>
<li><a href="/slides/hi/androidjava/convert-slide/">स्लाइड को छवियों के रूप में रेंडर करें</a></li>
<li><a href="/slides/hi/androidjava/manage-text/">पाठ और आकार संपादित करें</a></li>
</ul>
<p>स्लाइड वर्कफ़्लो</p>
<ul>
<li><a href="/slides/hi/androidjava/powerpoint-charts/">चार्ट</a></li>
<li><a href="/slides/hi/androidjava/powerpoint-animation/">एनीमेशन</a></li>
<li><a href="/slides/hi/androidjava/manage-media-files/">ऑडियो और वीडियो</a></li>
<li><a href="/slides/hi/androidjava/presentation-design/">स्लाइड डिजाइन</a></li>
<li><a href="/slides/hi/androidjava/merge-presentation/">प्रस्तुतियों को मिलाएँ</a></li>
</ul>
<p>उदाहरण</p>
<ul>
<li><a href="/slides/hi/androidjava/examples/">स्लाइड तत्व द्वारा उदाहरण</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>संदर्भ और समर्थन</b></p>
<hr>
<p>संदर्भ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">API संदर्भ</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">रिलीज़ नोट्स</a></li>
<li><a href="/slides/hi/androidjava/known-issues/">ज्ञात समस्याएँ</a></li>
<li><a href="https://products.aspose.com/slides/android-java/">उत्पाद पृष्ठ</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">डाउनलोड</a></li>
</ul>
<p>समर्थन</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">मुफ्त समर्थन फ़ोरम</a></li>
<li><a href="https://helpdesk.aspose.com/">भुगतान समर्थन हेल्पडेस्क</a></li>
</ul>
</div>
</div>

------

## **आपकी पहली प्रस्तुति**

लाइब्रेरी Aspose के Maven रिपॉजिटरी से आती है। नए Android Studio प्रोजेक्ट्स में पहले से ही *settings.gradle.kts* में एक `dependencyResolutionManagement` ब्लॉक मौजूद होता है। नीचे दिखाए गए `maven` लाइन को उस ब्लॉक के भीतर `repositories` ब्लॉक में जोड़ें, दूसरे ब्लॉक को चिपकाने के बजाय:

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

फिर लाइब्रेरी को *app/build.gradle.kts* में जोड़ें और प्रोजेक्ट को सिंक करें:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[स्थापना](/slides/hi/androidjava/install-aspose-slides-for-android-via-java/) में Groovy बिल्ड स्क्रिप्ट, मैन्युअल JAR फ़ाइल और संस्करण चुनने की विधि बताई गई है। आपकी पहली प्रस्तुति का कोड [प्रस्तुति बनाएं](/slides/hi/androidjava/create-presentation/) में है: यह एक टेक्स्ट बॉक्स को स्लाइड पर जोड़ता है और प्रस्तुति को आपके ऐप के स्टोरेज में सहेजता है। यह नमूना APK में संकलित और बनाया गया है; इसे डिवाइस पर नहीं चलाया गया है। बिना लाइसेंस के, सहेजी गई प्रस्तुतियों में मूल्यांकन वॉटरमार्क होगा — देखें [लाइसेंसिंग](/slides/hi/androidjava/licensing/).