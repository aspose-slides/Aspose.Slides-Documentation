---
title: Aspose.Slides for Android via Java स्थापित करें
type: docs
weight: 90
url: /hi/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- Aspose.Slides स्थापित करें
- Aspose.Slides डाउनलोड करें
- Aspose.Slides उपयोग करें
- Aspose.Slides स्थापना
- Gradle
- Maven रिपॉजिटरी
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java को Android Studio प्रोजेक्ट में Gradle का उपयोग करके Aspose के Maven रिपॉजिटरी से जोड़ें, या JAR फ़ाइल को मैन्युअल रूप से जोड़ें।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides for Android via Java को एक Android प्रोजेक्ट में कैसे जोड़ें। अनुशंसित तरीका है कि Gradle को Aspose के Maven रिपोजिटरी से लाइब्रेरी डाउनलोड करने दें। आप JAR फ़ाइल को डाउनलोड करके मैन्युअल रूप से अपने प्रोजेक्ट में भी जोड़ सकते हैं।

यह लाइब्रेरी Maven Central या Google के Maven रिपोजिटरी में प्रकाशित नहीं की गई है। यह Aspose के स्वयं के रिपोजिटरी से उपलब्ध है, `aspose-slides` आर्टिफैक्ट के रूप में, जिसमें `android.via.java` क्लासिफायर है।

## **Aspose के Maven रिपोजिटरी से स्थापित करें**

### **चरण 1: रिपोजिटरी जोड़ें**

नए Android Studio प्रोजेक्ट अपने रिपोजिटरी को *settings.gradle.kts* की `dependencyResolutionManagement` ब्लॉक में घोषित करते हैं, और Gradle उन रिपोजिटरी को अस्वीकार करता है जो किसी मॉड्यूल की बिल्ड फ़ाइल जोड़ती है। नीचे दिखाए गए `maven` लाइन को मौजूदा ब्लॉक के भीतर `repositories` ब्लॉक में जोड़ें, बजाय एक दूसरा `dependencyResolutionManagement` ब्लॉक चिपकाने के:

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

### **चरण 2: डिपेंडेंसी जोड़ें**

ऐप मॉड्यूल की बिल्ड फ़ाइल *app/build.gradle.kts* के `dependencies` ब्लॉक में लाइब्रेरी जोड़ें:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

कोऑर्डिनेट्स का अंतिम भाग, `android.via.java`, क्लासिफायर है जो लाइब्रेरी का Android बिल्ड चुनता है। इसके बिना, Gradle आर्टिफैक्ट नहीं ढूँढ़ पाएगा।

फिर Gradle फ़ाइलों के साथ प्रोजेक्ट को सिंक करें, ताकि Gradle लाइब्रेरी डाउनलोड करे।

### **संस्करण चुनें**

Aspose.Slides for Android via Java रिपोजिटरी में हर संस्करण के लिए नहीं बनाया गया है। इसके बिल्ड केवल कुछ Aspose.Slides for Java संस्करणों के लिए प्रकाशित होते हैं, और Android बिल्ड के बिना संस्करण रेजॉल्व नहीं हो पाएगा। सूचीबद्ध संस्करण [Aspose.Slides for Android via Java download page](https://releases.aspose.com/slides/androidjava/) पर चुनें।

### **Groovy बिल्ड स्क्रिप्ट्स**

यदि आपका प्रोजेक्ट Groovy बिल्ड स्क्रिप्ट्स का उपयोग करता है, तो *settings.gradle* की मौजूदा `dependencyResolutionManagement` ब्लॉक के भीतर `repositories` ब्लॉक में `maven` लाइन जोड़ें:

```groovy
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = 'https://releases.aspose.com/java/repo/' }
    }
}
```

और *app/build.gradle* में डिपेंडेंसी जोड़ें:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **JAR फ़ाइल को मैन्युअल रूप से जोड़ें**

1. JAR फ़ाइल को संस्करण के फ़ोल्डर से [Aspose's Maven repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) से डाउनलोड करें। संस्करण 26.9 के लिए, फ़ाइल *aspose-slides-26.9-android.via.java.jar* *26.9* फ़ोल्डर में है।
1. फ़ाइल को अपने प्रोजेक्ट की *app/libs* फ़ोल्डर में कॉपी करें। यदि फ़ोल्डर मौजूद नहीं है, तो उसे बनाएं।
1. फ़ाइल को *app/build.gradle.kts* के `dependencies` ब्लॉक में जोड़ें, फिर प्रोजेक्ट को सिंक करें:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **अपनी पहली प्रस्तुति बनाएं**

प्रोजेक्ट सिंक होने के बाद, [Create Presentations](/slides/hi/androidjava/create-presentation/) के साथ जारी रखें। इसका पहला उदाहरण स्लाइड में एक टेक्स्ट बॉक्स जोड़ता है और प्रस्तुति को आपके ऐप की निजी स्टोरेज में सहेजता है, जिसके लिए कोई स्टोरेज परमिशन आवश्यक नहीं है। बिना लाइसेंस के, Aspose.Slides प्रत्येक सहेजी गई स्लाइड में एक इवैल्यूएशन वॉटरमार्क जोड़ता है; देखें [Licensing](/slides/hi/androidjava/licensing/)।

## **संस्करणीकरण**

2018 से, Aspose.Slides for Android via Java का संस्करणीकरण Aspose.Slides for Java के अनुरूप है। Android बिल्ड हर Java संस्करण के लिए प्रकाशित नहीं होते; देखें [Choose a Version](#choose-a-version)।

## **अक्सर पूछे जाने वाले प्रश्न**

### Aspose.Slides का सही इंटेग्रेशन कैसे सत्यापित करें?

अपने प्रोजेक्ट को बिल्ड करें, एक खाली [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) का उदाहरण बनाएं और उसे नया नाम देकर सहेजें। यदि फ़ाइल बिना किसी अपवाद के बन जाती है, तो लाइब्रेरी सफलतापूर्वक एकीकृत हो गई है।

### बड़ी प्रस्तुतियों को प्रोसेस करते समय मेमोरी उपयोग को कैसे सीमित करें?

प्रत्येक [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) इंस्टेंस की [dispose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#dispose--) मेथड को `finally` ब्लॉक में कॉल करके उसके संसाधनों को तुरंत मुक्त करें, और एक बार में एक बड़ी प्रस्तुति प्रोसेस करें। यह आउट-ऑफ-मेमोरी त्रुटियों को रोकने और बैच ऑपरेशनों के दौरान समग्र मेमोरी उपयोग को पूर्वानुमेय रखने में मदद करता है।

### क्या मैं अनचाहे एक्सपोर्ट फॉर्मैट्स को बाहर रख कर अंतिम JAR आकार को छोटा कर सकता हूँ?

वर्तमान Aspose.Slides रिलीज़ एक एकल मोनोलीथिक लाइब्रेरी के रूप में वितरित होती है, इसलिए आप बिल्ड समय पर PDF या SVG जैसे विशिष्ट एक्सपोर्टर्स को अक्षम नहीं कर सकते।