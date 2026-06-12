---
title: Správa vlastností prezentace v C++
linktitle: Vlastnosti prezentace
type: docs
weight: 70
url: /cs/cpp/presentation-properties/
keywords:
- Vlastnosti PowerPointu
- Vlastnosti prezentace
- Vlastnosti dokumentu
- Vestavěné vlastnosti
- Vlastní vlastnosti
- Rozšířené vlastnosti
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
description: "Ovládejte vlastnosti prezentace v Aspose.Slides for C++ a zjednodušte vyhledávání, značkování a pracovní postup ve svých souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides podporuje dva typy vlastností dokumentu: **Vestavěné** a **Vlastní**. Oba tyto typy vlastností lze snadno přistupovat a spravovat pomocí API Aspose.Slides.

Aspose.Slides umožňuje pracovat s vlastnostmi dokumentu prezentace pomocí rozhraní [IDocumentProperties](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_document_properties). Instance tohoto rozhraní je vrácena metodou [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_documentproperties/). Následující příklady ukazují, jak číst, upravovat a spravovat tyto vlastnosti.

{{% alert color="primary" %}} 
Všimněte si, že nemůžete nastavit hodnoty pro pole **Application** a **Producer**, protože se v těchto polích zobrazí Aspose Ltd. a Aspose.Slides for C++ x.x.x.
{{% /alert %}} 

## **Správa vlastností prezentace**

Microsoft PowerPoint poskytuje funkci pro přidání některých vlastností do souborů prezentace. Tyto vlastnosti dokumentu umožňují uložit užitečné informace společně s dokumenty (soubory prezentace). Existují dva druhy vlastností dokumentu:

- Systemově definované (Vestavěné) vlastnosti
- Uživatelem definované (Vlastní) vlastnosti

**Vestavěné** vlastnosti obsahují obecné informace o dokumentu, jako je název dokumentu, jméno autora, statistiky dokumentu a podobně. **Vlastní** vlastnosti jsou ty, které uživatelé definují jako páry **Název/Hodnota**, kde jak název, tak hodnota jsou definovány uživatelem. Pomocí Aspose.Slides for C++ mohou vývojáři přistupovat a upravovat hodnoty vestavěných i vlastních vlastností. Microsoft PowerPoint 2007 umožňuje spravovat vlastnosti dokumentu souborů prezentace. Stačí kliknout na ikonu Office a poté na položku nabídky **Prepare | Properties | Advanced Properties** v Microsoft PowerPoint 2007. Po výběru položky **Advanced Properties** se zobrazí dialogové okno, které umožňuje spravovat vlastnosti dokumentu souboru PowerPoint. V **Properties Dialog** můžete vidět mnoho záložek, jako **General, Summary, Statistics, Contents a Custom**. Všechny tyto záložky umožňují konfigurovat různé druhy informací souvisejících se soubory PowerPoint. Záložka **Custom** slouží k správě vlastních vlastností souborů PowerPoint.

## **Přístup k vestavěným vlastnostem**

Tyto vlastnosti, jak je vystavuje objekt **IDocumentProperties**, zahrnují: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** a **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Úprava vestavěných vlastností**

Úprava vestavěných vlastností souborů prezentace je tak snadná, jako jejich čtení. Jednoduše můžete přiřadit řetězcovou hodnotu libovolné požadované vlastnosti a hodnota vlastnosti bude upravena. V příkladu níže jsme ukázali, jak lze upravit vestavěné vlastnosti dokumentu souboru prezentace.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Přidání vlastních vlastností prezentace**

Aspose.Slides for C++ také umožňuje vývojářům přidat vlastní hodnoty pro vlastnosti dokumentu prezentace. Níže je uveden příklad, který ukazuje, jak nastavit vlastní vlastnosti pro prezentaci.

``` cpp
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

Aspose.Slides poskytuje vlastnost [LanguageId](https://reference.aspose.com/slides/cs/cpp/aspose.slides.baseportionformat/set_languageid/) (vystavěnou třídou [PortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/portionformat/)), která umožňuje nastavit jazyk kontroly pravopisu pro dokument PowerPoint. Jazyk kontroly pravopisu je jazyk, pro který jsou v PowerPointu kontrolovány pravopis a gramatika.

Tento C++ kód ukazuje, jak nastavit jazyk kontroly pravopisu pro PowerPoint:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
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
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Nastavení výchozího jazyka**

Tento C++ kód ukazuje, jak nastavit výchozí jazyk pro celou prezentaci PowerPoint:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Přidá nový obdélníkový tvar s textem
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Checks the first portion language
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Živý příklad**

Vyzkoušejte online aplikaci **Aspose.Slides Metadata** a podívejte se, jak pracovat s vlastnostmi dokumentu pomocí Aspose.Slides API:

[![Zobrazit a upravit metadata PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## ***Často kladené otázky**

**Jak mohu odebrat vestavěnou vlastnost z prezentace?**

Vestavěné vlastnosti jsou neoddělitelnou součástí prezentace a nelze je zcela odstranit. Můžete však buď změnit jejich hodnoty, nebo je nastavit na prázdné, pokud to daná vlastnost umožňuje.

**Co se stane, když přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte vlastnost předtím odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu přistupovat k vlastnostem prezentace bez úplného načtení prezentace?**

Ano, můžete přistupovat k vlastnostem prezentace bez úplného načtení pomocí metody `GetPresentationInfo` ze třídy [PresentationFactory](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentationfactory/). Poté využijte metodu `ReadDocumentProperties` poskytovanou rozhraním [IPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/) pro efektivní čtení vlastností, což šetří paměť a zlepšuje výkon.