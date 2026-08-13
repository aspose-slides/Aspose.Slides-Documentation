---
title: Správa vlastností prezentace v C++
linktitle: Vlastnosti prezentace
type: docs
weight: 70
url: /cs/cpp/presentation-properties/
keywords:
- Vlastnosti PowerPoint
- Vlastnosti prezentace
- Vlastnosti dokumentu
- Vestavěné vlastnosti
- Vlastní vlastnosti
- Pokročilé vlastnosti
- Správa vlastností
- Úprava vlastností
- Metadata dokumentu
- Úprava metadat
- Jazyk kontroly pravopisu
- Výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Mistrně spravujte vlastnosti prezentace v Aspose.Slides pro C++ a zefektivněte vyhledávání, branding a workflow ve vašich souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides podporuje dva typy vlastností dokumentu: **Vestavěné** a **Vlastní**. Oba tyto typy vlastností lze snadno získat a spravovat pomocí API Aspose.Slides.

Aspose.Slides umožňuje pracovat s vlastnostmi dokumentu prezentace prostřednictvím rozhraní [IDocumentProperties](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_document_properties). Instance tohoto rozhraní je vrácena metodou [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_documentproperties/). Následující příklady ukazují, jak číst, upravovat a spravovat tyto vlastnosti.

{{% alert color="info" %}} 
Všimněte si, že nemůžete nastavit hodnoty pro pole **Application** a **Producer**, protože v těchto polích bude zobrazena značka Aspose Ltd. a Aspose.Slides for C++ x.x.x.
{{% /alert %}} 

## **Správa vlastností prezentace**

Microsoft PowerPoint poskytuje funkci pro přidání některých vlastností do souborů prezentace. Tyto vlastnosti dokumentu umožňují uložit užitečné informace spolu s dokumenty (soubory prezentace). Existují dva druhy vlastností dokumentu:

- Systémem definované (vestavěné) vlastnosti
- Uživatelem definované (vlastní) vlastnosti

**Vestavěné** vlastnosti obsahují obecné informace o dokumentu, jako je název dokumentu, jméno autora, statistiky dokumentu a další. **Vlastní** vlastnosti jsou ty, které definují uživatelé jako páry **Název/Hodnota**, kde jak název, tak hodnota jsou definovány uživatelem. Pomocí Aspose.Slides for C++ mohou vývojáři přistupovat a měnit hodnoty vestavěných i vlastních vlastností. Microsoft PowerPoint 2007 umožňuje spravovat vlastnosti dokumentu souborů prezentace. Stačí kliknout na ikonu Office a poté na položku nabídky **Prepare | Properties | Advanced Properties** v Microsoft PowerPoint 2007. Po výběru položky **Advanced Properties** se zobrazí dialogové okno, které umožňuje spravovat vlastnosti dokumentu souboru PowerPoint. V **Properties Dialog** můžete vidět mnoho záložek, jako **General, Summary, Statistics, Contents** a **Custom**. Všechny tyto záložky umožňují konfigurovat různé druhy informací souvisejících se soubory PowerPoint. Záložka **Custom** se používá k správě vlastních vlastností souborů PowerPoint.

## **Přístup k vestavěným vlastnostem**

Tyto vlastnosti, jak je vystavuje objekt **IDocumentProperties**, zahrnují: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Datum vytvoření), **Modified** (Datum úprav), **Printed** (Datum posledního tisku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Je sdíleno mezi různými producenty?), **PresentationFormat**, **Subject** a **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Úprava vestavěných vlastností**

Úprava vestavěných vlastností souborů prezentace je stejně jednoduchá jako jejich přístup. Jednoduše můžete přiřadit řetězcovou hodnotu libovolné požadované vlastnosti a hodnota vlastnosti bude změněna. V níže uvedeném příkladu jsme ukázali, jak můžeme upravit vestavěné vlastnosti dokumentu souboru prezentace.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Přidání vlastních vlastností prezentace**

Aspose.Slides for C++ také umožňuje vývojářům přidat vlastní hodnoty pro vlastnosti dokumentu prezentace. Níže je uveden příklad, který ukazuje, jak nastavit vlastní vlastnosti pro prezentaci.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Vytvořte instanci třídy Presentation
auto presentation = System::MakeObject<Presentation>();

// Získání vlastností dokumentu
auto documentProperties = presentation->get_DocumentProperties();

// Přidání vlastních vlastností
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Získání názvu vlastnosti na konkrétním indexu
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Odstranění vybrané vlastnosti
documentProperties->RemoveCustomProperty(getPropertyName);

// Uložení prezentace
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Přístup a úprava vlastních vlastností**

Aspose.Slides for C++ také umožňuje vývojářům přistupovat k hodnotám vlastních vlastností. Níže je uveden příklad, který ukazuje, jak můžete přistupovat a upravovat všechny tyto vlastní vlastnosti pro prezentaci.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Nastavení jazyka kontroly pravopisu**

Aspose.Slides poskytuje vlastnost [LanguageId](https://reference.aspose.com/slides/cs/cpp/aspose.slides.baseportionformat/set_languageid/) (vystavenou třídou [PortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/portionformat/)), která vám umožní nastavit jazyk kontroly pravopisu pro dokument PowerPoint. Jazyk kontroly pravopisu je jazyk, pro který jsou v PowerPointu kontrolovány pravopis a gramatika.

Tento C++ kód ukazuje, jak nastavit jazyk kontroly pravopisu pro PowerPoint:

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
// nastavit Id jazyka kontroly pravopisu

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Nastavení výchozího jazyka**

Tento C++ kód ukazuje, jak nastavit výchozí jazyk pro celou prezentaci PowerPoint:

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

// Přidá nový obdélníkový tvar s textem
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Kontroluje jazyk první části
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Živý příklad**

Vyzkoušejte online aplikaci [**Aspose.Slides Metadata**](https://products.aspose.app/slides/cs/metadata), která ukazuje, jak pracovat s vlastnostmi dokumentu pomocí API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## ***Často kladené otázky**

### Jak mohu odstranit vestavěnou vlastnost z prezentace?

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete však změnit jejich hodnoty nebo je nastavit na prázdné, pokud to konkrétní vlastnost umožňuje.

### Co se stane, když přidám vlastní vlastnost, která již existuje?

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou hodnotou. Není nutné vlastnost předtím odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

### Mohu přistupovat k vlastnostem prezentace bez úplného načtení prezentace?

Ano, můžete přistupovat k vlastnostem prezentace bez úplného načtení prezentace pomocí metody `GetPresentationInfo` ze třídy [PresentationFactory](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentationfactory/). Poté použijte metodu `ReadDocumentProperties` poskytovanou rozhraním [IPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/) k efektivnímu načtení vlastností, čímž šetříte paměť a zvyšujete výkon.