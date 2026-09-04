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
- Zabudované vlastnosti
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
description: Ovládněte vlastnosti prezentace v Aspose.Slides pro C++ a zefektivněte vyhledávání, značkování a pracovní proces ve vašich souborech PowerPoint a OpenDocument.
---
## **Úvod**

Aspose.Slides podporuje dva typy vlastností dokumentu: **Built-in** a **Custom**. Oba tyto typy vlastností lze snadno získat a spravovat pomocí API Aspose.Slides.

Aspose.Slides vám umožňuje pracovat s vlastnostmi dokumentu prezentace prostřednictvím rozhraní [IDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/). Instance tohoto rozhraní je vrácena metodou [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/get_documentproperties/). Následující příklady ukazují, jak číst, upravovat a spravovat tyto vlastnosti.

{{% alert color="info" title="Poznámka" %}}
Všimněte si, že nelze nastavit hodnoty pro pole **Application** a **Producer**, protože se v těchto polích zobrazí Aspose Ltd. a Aspose.Slides pro C++ x.x.x.
{{% /alert %}} 

## **Správa vlastností prezentace**

Microsoft PowerPoint poskytuje funkci pro přidání některých vlastností do souborů prezentace. Tyto vlastnosti dokumentu umožňují uložit užitečné informace společně s dokumenty (soubory prezentace). Existují dva typy vlastností dokumentu, jak je uvedeno níže

- Systémově definované (Built-in) vlastnosti
- Uživatelsky definované (Custom) vlastnosti

**Built-in** vlastnosti obsahují obecné informace o dokumentu, jako je název dokumentu, jméno autora, statistiky dokumentu a podobně. **Custom** vlastnosti jsou takové, které uživatelé definují jako dvojice Název/ Hodnota, kde název i hodnota jsou definovány uživatelem. Pomocí Aspose.Slides pro C++ mohou vývojáři získávat a měnit hodnoty zabudovaných i uživatelských vlastností. Microsoft PowerPoint 2007 umožňuje spravovat vlastnosti dokumentu souborů prezentace. Stačí kliknout na ikonu Office a poté na položku nabídky **Prepare | Properties | Advanced Properties** v Microsoft PowerPoint 2007. Po výběru položky **Advanced Properties** se zobrazí dialogové okno umožňující spravovat vlastnosti dokumentu PowerPoint souboru. V **Properties Dialog** vidíte mnoho záložek, jako jsou **General, Summary, Statistics, Contents a Custom**. Všechny tyto záložky umožňují konfigurovat různé typy informací souvisejících se soubory PowerPoint. Záložka **Custom** slouží ke správě vlastních (custom) vlastností souborů PowerPoint.

## **Čtení veřejných vlastností z šifrované prezentace**

Otevírací heslo obvykle chrání jak obsah prezentace, tak vlastnosti dokumentu. Když je prezentace šifrována předáním hodnoty `false` metodě [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), zůstávají její vlastnosti dokumentu veřejné. Aplikace pak může předat `true` metodě [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) a načíst veřejná metadata bez zadání otevíracího hesla.

`set_OnlyLoadDocumentProperties` řídí, co Aspose.Slides načte; nic neodšifruje. Pokud byly vlastnosti zahrnuty do šifrování, načtení bez hesla selže. Pokud prezentace není šifrována, volba je ignorována a načte se celá prezentace.

Následující příklad ověřuje režim načítání pomocí [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) a následně čte zabudované vlastnosti pomocí [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

V tomto režimu se nenačítá obsah snímků. Snímky, master snímky, rozvržení, tvary, média a další objekty prezentace nejsou k dispozici. Aplikace by měly vždy zkontrolovat `get_IsOnlyDocumentPropertiesLoaded` před provedením operace vyžadující kompletní model objektů prezentace.

{{% alert color="warning" title="Varování" %}}
Veřejná metadata mohou odhalit jména autorů, názvy, předměty, klíčová slova, informace o společnosti, komentáře a vlastní hodnoty. Šifrujte citlivé vlastnosti spolu s prezentací. Nechte je veřejné pouze v případě, že indexování, klasifikace, vyhledávání nebo systémy pro správu dokumentů mají specifický požadavek na přístup k nim bez hesla.
{{% /alert %}}

## **Aktualizace vlastností šifrované prezentace**

U šifrovaného souboru PPTX je prezentace načtená po volání `set_OnlyLoadDocumentProperties(true)` určena ke čtení veřejných metadat. Aspose.Slides nemůže uložit změněné vlastnosti z tohoto objektu jen s metadaty, protože veřejné vlastnosti musí zůstávat v souladu s odpovídajícími daty uvnitř šifrované prezentace. Aktualizace tedy vyžaduje správné otevírací heslo a kompletní načtení.

Následující příklad otevře prezentaci pomocí [LoadOptions::set_Password](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_password/), aktualizuje veřejné zabudované vlastnosti a výsledek uloží. Pak použije [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) k ověření, že šifrování zůstalo zachováno, a znovu otevře veřejná metadata bez hesla, aby ověřil nové hodnoty:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

Pokud aplikace nemá povoleno dešifrovat nebo načíst obsah prezentace, musí veřejné vlastnosti šifrovaného souboru PPTX považovat za pouze ke čtení.

## **Přístup k zabudovaným vlastnostem**

Tyto vlastnosti vystavené objektovým **IDocumentProperties** zahrnují: **Creator(Author)**, **Description**, **KeyWords**, **Created** (datum vytvoření), **Modified** (datum úpravy), **Printed** (datum posledního tisku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Je sdílený mezi různými producenty?), **PresentationFormat**, **Subject** a **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Úprava zabudovaných vlastností**

Úprava zabudovaných vlastností souborů prezentace je stejně snadná jako k nim přistupovat. Jednoduše můžete přiřadit řetězcovou hodnotu k libovolné požadované vlastnosti a hodnota bude změněna. V níže uvedeném příkladu jsme ukázali, jak lze upravit zabudované vlastnosti dokumentu prezentace.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Přidání vlastních vlastností prezentace**

Aspose.Slides pro C++ také umožňuje vývojářům přidat vlastní hodnoty pro vlastnosti dokumentu prezentace. Níže je uveden příklad, který ukazuje, jak nastavit vlastní vlastnosti pro prezentaci.

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

// Odebrání vybrané vlastnosti
documentProperties->RemoveCustomProperty(getPropertyName);

// Uložení prezentace
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Přístup a úprava vlastních vlastností**

Aspose.Slides pro C++ také umožňuje vývojářům přistupovat k hodnotám vlastních vlastností. Níže je uveden příklad, který ukazuje, jak můžete přistupovat a upravovat všechny tyto vlastní vlastnosti pro prezentaci.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Nastavení jazyka kontroly pravopisu**

Aspose.Slides poskytuje vlastnost [LanguageId](https://reference.aspose.com/slides/cs/cpp/aspose.slides/baseportionformat/set_languageid/) (vystavenou třídou [PortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/portionformat/)), která umožňuje nastavit jazyk kontroly pravopisu pro dokument PowerPoint. Jazyk kontroly pravopisu je jazyk, pro který se v PowerPointu kontrolují pravopis a gramatika.

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
// nastavte Id jazyka pro kontrolu pravopisu

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

Vyzkoušejte online aplikaci [**Aspose.Slides Metadata**](https://products.aspose.app/slides/cs/metadata) a zjistěte, jak pracovat s vlastnostmi dokumentu pomocí API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## **Často kladené otázky**

**Jak mohu odstranit zabudovanou vlastnost z prezentace?**

Zabudované vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete je však buď změnit, nebo nastavit na prázdný řetězec, pokud to konkrétní vlastnost umožňuje.

**Co se stane, když přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou hodnotou. Nemusíte vlastnost předem odstranit nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu přistupovat k vlastnostem prezentace bez úplného načtení prezentace?**

Ano. Použijte [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) a následně [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/), abyste načetli uložená metadata dokumentu bez vytváření instance [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/). Viz [Build a Lightweight Presentation Inventory](/slides/cs/cpp/examine-presentation/) pro kompletní příklad reportování a omezení specifických formátů.

**Mohu číst veřejné vlastnosti šifrované prezentace bez jejího otevíracího hesla?**

Ano. Prezentace musí být šifrována předáním hodnoty `false` metodě `set_EncryptDocumentProperties` a musí být načtena předáním `true` metodě `set_OnlyLoadDocumentProperties`.

**Mohu aktualizovat šifrovaný soubor PPTX v režimu pouze vlastností dokumentu?**

Ne. Veřejná a šifrovaná data vlastností musí zůstávat konzistentní, proto aktualizace šifrovaného souboru PPTX vyžaduje načtení celé prezentace se správným otevíracím heslem.