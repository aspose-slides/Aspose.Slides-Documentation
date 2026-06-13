---
title: VBA मैक्रो
type: docs
weight: 150
url: /hi/nodejs-java/examples/elements/vba-macro/
keywords:
- कोड उदाहरण
- VBA
- मैक्रो
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js के लिए Aspose.Slides via Java के साथ प्रस्तुतियों को स्वचालित करें: स्पष्ट JavaScript उदाहरणों का उपयोग करके PPT, PPTX और ODP में VBA मैक्रो बनाएं, आयात करें, और सुरक्षित रखें।"
---
यह लेख दिखाता है कि **Aspose.Slides for Node.js via Java** का उपयोग करके VBA मैक्रो को कैसे जोड़ें, एक्सेस करें, और हटाएं।

## **Add a VBA Macro**

VBA प्रोजेक्ट और एक सरल मैक्रो मॉड्यूल के साथ एक प्रस्तुति बनाएं।

```js
function addVbaMacro() {
    let presentation = new aspose.slides.Presentation();
    try {
        presentation.setVbaProject(new aspose.slides.VbaProject());

        let module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.save("vba_macro.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a VBA Macro**

VBA प्रोजेक्ट से पहला मॉड्यूल प्राप्त करें।

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // मान लीजिए कि प्रस्तुति में कम से कम एक VBA मॉड्यूल है।
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a VBA Macro**

VBA प्रोजेक्ट से एक मॉड्यूल हटाएं।

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // मान लीजिए कि प्रस्तुति में कम से कम एक VBA मॉड्यूल है।
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```