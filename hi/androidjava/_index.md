---
title: Aspose.Slides for Android via Java
second_title: Aspose.Slides for Android
type: docs
weight: 40
url: /hi/androidjava/
keywords:
- दस्तावेज़ीकरण
- प्रस्तुति प्रक्रिया
- प्रस्तुति रूपांतरण
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "यहाँ से शुरू करें: अपने ऐप में Aspose.Slides for Android via Java जोड़ें, पहला प्रस्तुति बनाएं, और सामान्य कार्यों, API रेफ़रेंस और समर्थन के लिए गाइड खोजें।"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java एक क्लास लाइब्रेरी है जो Android एप्लिकेशन में PowerPoint और OpenDocument प्रस्तुतियों को बनाने, पढ़ने, संपादित करने और रूपांतरित करने के लिए है, बिना Microsoft PowerPoint के।

यह PPT, PPTX, PPS, POT और ODP फ़ाइलों को लोड और सहेजती है, जिसमें मैक्रो‑समर्थित और टेम्पलेट संस्करण शामिल हैं, और PDF, XPS, HTML, SVG, TIFF, Markdown और इमेजेज़ में निर्यात करता है।

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>शुरू करें</b></p>
<hr>
<p>शुरुआत</p>
<ul>
<li><a href="/slides/hi/androidjava/install-aspose-slides-for-android-via-java/">स्थापना</a></li>
<li><a href="/slides/hi/androidjava/create-presentation/">अपना पहला प्रस्तुति बनाएं</a></li>
<li><a href="/slides/hi/androidjava/getting-started/">शुरूआत गाइड</a></li>
</ul>
<p>मूल्यांकन</p>
<ul>
<li><a href="/slides/hi/androidjava/supported-file-formats/">समर्थित फ़ाइल फ़ॉर्मेट</a></li>
<li><a href="/slides/hi/androidjava/evaluate-aspose-slides/">ट्रायल सीमाएँ</a></li>
<li><a href="/slides/hi/androidjava/licensing/">लाइसेंसिंग</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides के साथ निर्माण</b></p>
<hr>
<p>सामान्य कार्य</p>
<ul>
<li><a href="/slides/hi/androidjava/open-presentation/">एक प्रस्तुति खोलें</a></li>
<li><a href="/slides/hi/androidjava/save-presentation/">एक प्रस्तुति सहेजें</a></li>
<li><a href="/slides/hi/androidjava/convert-powerpoint-to-pdf/">PDF में कनवर्ट करें</a></li>
<li><a href="/slides/hi/androidjava/convert-slide/">स्लाइड को इमेज के रूप में रेंडर करें</a></li>
<li><a href="/slides/hi/androidjava/manage-text/">टेक्स्ट और शैप्स को संपादित करें</a></li>
</ul>
<p>Slides कार्य प्रवाह</p>
<ul>
<li><a href="/slides/hi/androidjava/powerpoint-charts/">चार्ट्स</a></li>
<li><a href="/slides/hi/androidjava/powerpoint-animation/">एनिमेशन</a></li>
<li><a href="/slides/hi/androidjava/manage-media-files/">ऑडियो और वीडियो</a></li>
<li><a href="/slides/hi/androidjava/presentation-design/">स्लाइड डिज़ाइन</a></li>
<li><a href="/slides/hi/androidjava/merge-presentation/">प्रेजेंटेशन को मर्ज करें</a></li>
</ul>
<p>उदाहरण</p>
<ul>
<li><a href="/slides/hi/androidjava/examples/">स्लाइड तत्व द्वारा उदाहरण</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>संदर्भ &amp; समर्थन</b></p>
<hr>
<p>संदर्भ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/hi/androidjava/">API संदर्भ</a></li>
<li><a href="https://releases.aspose.com/slides/hi/androidjava/release-notes/">रिलीज़ नोट्स</a></li>
<li><a href="/slides/hi/androidjava/known-issues/">ज्ञात समस्याएँ</a></li>
<li><a href="https://releases.aspose.com/slides/hi/androidjava/">डाउनलोड</a></li>
</ul>
<p>समर्थन</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/hi/11">नि:शुल्क समर्थन फ़ोरम</a></li>
<li><a href="https://helpdesk.aspose.com/">भुगतान समर्थन हेल्पडेस्क</a></li>
</ul>
</div>
</div>

------

## **आपकी पहली प्रस्तुति**

यह लाइब्रेरी Aspose के Maven रिपॉजिटरी से आती है। नए Android Studio प्रोजेक्ट्स में पहले से ही *settings.gradle.kts* में `dependencyResolutionManagement` ब्लॉक मौजूद रहता है। नीचे दिखाए गए `maven` लाइन को `repositories` ब्लॉक के अंदर जोड़ें, दूसरे ब्लॉक को पेस्ट करने के बजाय:

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

[स्थापना](/slides/hi/androidjava/install-aspose-slides-for-android-via-java/) Groovy बिल्ड स्क्रिप्ट्स, मैनुअल JAR फ़ाइल, और संस्करण चुनने के तरीके को कवर करता है। आपकी पहली प्रस्तुति का कोड [प्रस्तुतीकरण बनाएं](/slides/hi/androidjava/create-presentation/) पर है: यह स्लाइड में एक टेक्स्ट बॉक्स जोड़ता है और प्रस्तुति को आपके ऐप की स्टोरेज में सहेजता है। उदाहरण को संकलित करके एक APK में निर्मित किया गया है; इसे किसी डिवाइस पर नहीं चलाया गया है। बिना लाइसेंस के, सहेजी गई प्रस्तुतियों पर मूल्यांकन जलचिह्न रहता है — देखें [लाइसेंसिंग](/slides/hi/androidjava/licensing/).