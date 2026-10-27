---
title: Use Slides from C++
description: Create, edit and render presentations from native C++ code.
type: docs
url: /features/cpp-api/
weight: 390
feature_id: cpp-api
feature_group: languages
translationKey: slides-feature-cpp-api
feature_catalogue_version: 3
feature_guides:
- /slides/cpp/installation/
---

## **Overview**

Add the Slides C++ library to a native application and use its presentation objects for document processing. The C++ guides cover installation, compiler requirements and common tasks such as opening files, editing slides and exporting output.

## **Usage example**

This example uses Aspose.Slides for C++. Configure the include paths, native libraries and runtime library locations using the [installation guide](/slides/cpp/installation/). Compile this complete program, then run it in a writable directory. It creates one slide containing a text box and saves *hello.pptx* without an input file.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto title = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    title->get_TextFrame()->set_Text(u"Hello from C++");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

The coordinates and dimensions are in points. Evaluation output carries a watermark. The program uses native C++ objects and does not start Java or .NET.

## **FAQ**

### **Do I need to install Java or .NET for this binding?**

The C++ library does not require either runtime. Follow its own compiler, operating-system and native dependency requirements.

### **Which headers and libraries are needed to build the example?**

The example includes the presentation, slide, shape and text-frame headers, the output-format header and the smart-pointer header. Configure both the Aspose.Slides native library and its CodePorting framework dependency, including their matching include and linker paths, as described in [Installation](/slides/cpp/installation/).

### **How is presentation lifetime managed in the C++ binding?**

The binding uses reference-counted smart pointers for object ownership. Keep the presentation alive while using its slides and shapes, and release presentation resources when processing is finished. The example explicitly releases those resources after saving.

## **Guides**

- [Installation (C++)](/slides/cpp/installation/)
