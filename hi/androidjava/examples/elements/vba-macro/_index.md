---
title: VBA मैक्रो
type: docs
weight: 150
url: /hi/androidjava/examples/elements/vba-macro/
keywords:
- कोड उदाहरण
- VBA
- मैक्रो
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ प्रस्तुतियों को स्वचालित करें: स्पष्ट Java उदाहरणों का उपयोग करके PPT, PPTX, और ODP में VBA मैक्रो बनाएं, चलाएँ, आयात करें और सुरक्षित रखें।"
---
यह लेख दिखाता है कि **Aspose.Slides for Android via Java** का उपयोग करके VBA मैक्रोज़ को कैसे जोड़ें, पहुँचें, और हटाएँ।

## **VBA मैक्रो जोड़ें**

VBA प्रोजेक्ट और एक सरल मैक्रो मॉड्यूल के साथ एक प्रस्तुति बनाएं।

```java
static void addVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");
    } finally {
        presentation.dispose();
    }
}
```

## **VBA मैक्रो तक पहुँचें**

VBA प्रोजेक्ट से पहला मॉड्यूल प्राप्त करें।

```java
static void accessVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        IVbaModule firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **VBA मैक्रो हटाएँ**

VBA प्रोजेक्ट से एक मॉड्यूल हटाएँ।

```java
static void removeVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.getVbaProject().getModules().remove(module);
    } finally {
        presentation.dispose();
    }
}
```