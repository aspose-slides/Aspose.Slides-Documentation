---
title: Hantera presentationsegenskaper i C++
linktitle: Presentationsegenskaper
type: docs
weight: 70
url: /sv/cpp/presentation-properties/
keywords:
- PowerPoint-egenskaper
- presentationsegenskaper
- dokumentegenskaper
- inbyggda egenskaper
- anpassade egenskaper
- avancerade egenskaper
- hantera egenskaper
- modifiera egenskaper
- dokumentmetadata
- redigera metadata
- korrekturspråk
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Behärska presentationsegenskaper i Aspose.Slides för C++ och effektivisera sökning, varumärkesprofilering och arbetsflöde i dina PowerPoint- och OpenDocument-filer."
---
## **Introduktion**

Aspose.Slides stödjer två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Båda dessa egenskapstyper kan enkelt nås och hanteras med Aspose.Slides API.

Aspose.Slides allows you to work with presentation document properties through the [IDocumentProperties](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_document_properties) interface. An instance of this interface is returned by the [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_documentproperties/) method. The following examples show how to read, modify, and manage these properties.

{{% alert color="info" title="Note" %}}
Observera att du inte kan ange värden för fälten **Application** och **Producer**, eftersom Aspose Ltd. och Aspose.Slides för C++ x.x.x kommer att visas i dessa fält.
{{% /alert %}} 

## **Hantera presentationsegenskaper**

Microsoft PowerPoint provides a feature to add some properties to the presentation files. These document properties allow some useful information to be stored along with the documents (presentation files). There are two kinds of document properties as follows

- Systemdefinierade (Inbyggda) egenskaper
- Användardefinierade (Anpassade) egenskaper

**Inbyggda** properties contain general information about the document like document title, author's name, document statistics and so on. **Custom** properties are those ones, which are defined by the users as **Name/Value** pairs, where both name and value are defined by the user. Using Aspose.Slides for C++, developers can access and modify the values of built-in properties as well as custom properties. Microsoft PowerPoint 2007 allows managing the document properties of the presentation files. All you have to do is to click the Office icon and further **Förbered | Egenskaper | Avancerade egenskaper** menu item of the Microsoft PowerPoint 2007. After you select **Avancerade egenskaper** menu item, a dialog would appear allowing you to manage the document properties of the PowerPoint file. In the **Egenskapsdialog** you can see that there are many tab pages like **Allmänt, Sammanfattning, Statistik, Innehåll och Anpassat**. All these tab pages allow configuring different kinds of information related to the PowerPoint files. **Anpassat** tab is used to manage custom properties of the PowerPoint files.

## **Åtkomst till inbyggda egenskaper**

These properties as exposed by **IDocumentProperties** object include: **Creator(Author)**, **Description**, **KeyWords** **Created** (Creation Date), **Modified** Modification Date, **Printed** Last Print Date, **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** and **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Ändra inbyggda egenskaper**

Modifying the built-in properties of presentation files is as easy as that of accessing them. You can simply assign a string value to any desired property and the property value would be modified. In the example given below, we have demonstrated that how we can modify the built-in document properties of the presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Lägg till anpassade presentationsegenskaper**

Aspose.Slides for C++ also allows developers to add the custom the values for presentation Document properties. An example is given below that shows how to set the custom properties for a presentation.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instansiera Presentation-klassen
auto presentation = System::MakeObject<Presentation>();

// Hämtar dokumentegenskaper
auto documentProperties = presentation->get_DocumentProperties();

// Lägger till anpassade egenskaper
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Hämtar egenskapsnamn på ett specifikt index
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Tar bort vald egenskap
documentProperties->RemoveCustomProperty(getPropertyName);

// Sparar presentationen
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Åtkomst till och ändra anpassade egenskaper**

Aspose.Slides for C++ also allows developers to access the values of custom properties. An example is given below that shows how can you access and modify all of these custom properties for a presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Ställ in korrekturspråk**

Aspose.Slides provides the [LanguageId](https://reference.aspose.com/slides/sv/cpp/aspose.slides/baseportionformat/set_languageid/) property (exposed by the [PortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/portionformat/) class) to allow you to set the proofing language for a PowerPoint document. The proofing language is the language for which spellings and grammar in the PowerPoint are checked.

This C++ code shows you how to set the proofing language for a PowerPoint:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// ange Id för ett korrekturspråk

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Ställ in standardspråk**

This C++ code shows you how to set the default language for an entire PowerPoint presentation:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Lägger till en ny rektangelform med text
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Kontrollerar språk för den första delen
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Liveexempel**

Try [**Aspose.Slides Metadata**](https://products.aspose.app/slides/sv/metadata) online app to see how to work with document properties via Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## **FAQ**

**How can I remove a built-in property from a presentation?**

Built-in properties are an integral part of the presentation and cannot be removed entirely. However, you can either change their values or set them to empty if allowed by the specific property.

**What happens if I add a custom property that already exists?**

If you add a custom property that already exists, its existing value will be overwritten with the new one. You do not need to remove or check the property beforehand, as Aspose.Slides automatically updates the property's value.

**Can I access presentation properties without fully loading the presentation?**

Yes. Use [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) and then [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) to read stored document metadata without creating a [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) instance. See [Build a Lightweight Presentation Inventory](/slides/sv/cpp/examine-presentation/) for a complete reporting example and format-specific limitations.