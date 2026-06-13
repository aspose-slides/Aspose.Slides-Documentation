---
title: Vba मैक्रो
type: docs
weight: 150
url: /hi/php-java/examples/elements/vba-macro/
keywords:
- vba मैक्रो
- vba मैक्रो जोड़ें
- vba मैक्रो तक पहुंचें
- vba मैक्रो हटाएँ
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके PHP में VBA मैक्रो के साथ काम करें: प्रोजेक्ट और मॉड्यूल जोड़ें या संपादित करें, मैक्रो पर हस्ताक्षर करें या उन्हें हटाएँ, और प्रस्तुति को PPT, PPTX और ODP में सहेजें।"
---
यह दर्शाता है कि **Aspose.Slides for PHP via Java** का उपयोग करके VBA मैक्रो को कैसे जोड़ें, एक्सेस करें और हटाएं।

## **VBA मैक्रो जोड़ें**

VBA प्रोजेक्ट और एक सरल मैक्रो मॉड्यूल के साथ एक प्रस्तुति बनाएं।

```php
function addVbaMacro() {
    $presentation = new Presentation();
    try {
        $presentation->setVbaProject(new VbaProject());

        $module = $presentation->getVbaProject()->getModules()->addEmptyModule("Module");
        $module->setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        $presentation->save("vba_macro.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```

## **VBA मैक्रो तक पहुंचें**

VBA प्रोजेक्ट से पहला मॉड्यूल प्राप्त करें।

```php
function accessVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        $firstModule = $presentation->getVbaProject()->getModules()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **VBA मैक्रो हटाएँ**

VBA प्रोजेक्ट से एक मॉड्यूल हटाएं।

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // मान लेते हैं कि VBA प्रोजेक्ट में कम से कम एक मॉड्यूल है।
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```