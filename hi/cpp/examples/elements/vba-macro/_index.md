---
title: VBA मैक्रो
type: docs
weight: 150
url: /hi/cpp/examples/elements/vba-macro/
keywords:
- कोड उदाहरण
- VBA
- मैक्रो
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ प्रस्तुतियों को स्वचालित करें: स्पष्ट C++ उदाहरणों का उपयोग करके PPT, PPTX और ODP में VBA मैक्रो बनाएं, चलाएँ, आयात करें और सुरक्षित बनाएं।"
---
यह लेख **Aspose.Slides for C++** का उपयोग करके VBA मैक्रो को जोड़ने, एक्सेस करने और हटाने का प्रदर्शन करता है।

## **VBA मैक्रो जोड़ें**

VBA प्रोजेक्ट और एक सरल मैक्रो मॉड्यूल के साथ एक प्रस्तुति बनाएं।

```cpp
static void AddVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->Dispose();
}
```

## **VBA मैक्रो एक्सेस करें**

VBA प्रोजेक्ट से पहला मॉड्यूल प्राप्त करें।

```cpp
static void AccessVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    auto firstModule = presentation->get_VbaProject()->get_Module(0);

    presentation->Dispose();
}
```

## **VBA मैक्रो हटाएँ**

VBA प्रोजेक्ट से एक मॉड्यूल हटाएँ।

```cpp
static void RemoveVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->get_VbaProject()->get_Modules()->Remove(module);

    presentation->Dispose();
}
```