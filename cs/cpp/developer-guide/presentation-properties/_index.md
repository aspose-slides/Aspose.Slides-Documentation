---
title: Spravovat vlastnosti prezentace v C++
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
- Spravovat vlastnosti
- Upravit vlastnosti
- Metadata dokumentu
- Upravit metadata
- Jazyk korektury
- Výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Ovládejte vlastnosti prezentace v Aspose.Slides pro C++ a zjednodušte vyhledávání, značkování a pracovní proces ve vašich souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides pro C++ podporuje **vestavěné** a **vlastní** vlastnosti dokumentu. Použijte tyto vlastnosti k čtení a aktualizaci metadat prezentace, jako je autor, název a uživatelem definované hodnoty.

Aspose.Slides vám umožňuje pracovat s vlastnostmi dokumentu prezentace pomocí rozhraní [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) . Instance tohoto rozhraní je vrácena pomocí [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). Následující příklady ukazují, jak tyto vlastnosti číst, měnit a spravovat.

{{% alert color="info" title="Note" %}}
Aspose.Slides spravuje metadata aplikace a výrobce při ukládání prezentací; tato pole identifikují software, který vytvořil výstup.
{{% /alert %}}

## **Spravovat vlastnosti prezentace**

Vlastnosti dokumentu ukládají popisné informace vedle obsahu prezentace. Rozdělují se do dvou kategorií:

- **Vestavěné vlastnosti** obsahují standardní metadata, jako je název, autor a statistiky dokumentu.
- **Vlastní vlastnosti** ukládají páry názvu/hodnoty definované uživatelem.

Aspose.Slides pro C++ poskytuje přístup k oběma kategoriím. V PowerPointu vyberte **Soubor → Info → Vlastnosti → Pokročilé vlastnosti** pro zobrazení metadat dokumentu. Dialog seskupuje informace do karet, jako jsou **Shrnutí**, **Statistiky**, **Obsah** a **Vlastní**. Použijte kartu **Vlastní** pro správu uživatelem definovaných vlastností.

## **Číst veřejné vlastnosti z šifrované prezentace**

Otevírací heslo obvykle chrání jak obsah prezentace, tak vlastnosti dokumentu. Když je prezentace šifrována předáním `false` metodě [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), její vlastnosti dokumentu zůstávají veřejné. Aplikace pak může předat `true` metodě [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) a číst veřejná metadata bez zadání otevíracího hesla.

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) řídí, co Aspose.Slides načítá; nic neodšifrovává. Pokud byly vlastnosti zahrnuty do šifrování, načtení bez hesla selže. Pokud prezentace není šifrovaná, možnost se ignoruje a načte se celá prezentace.

Příklad vyžaduje šifrovanou prezentaci, jejíž vlastnosti dokumentu zůstaly veřejné. Ověřuje režim načítání pomocí [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/), a poté čte vestavěné vlastnosti pomocí [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = System::MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto documentProperties = presentation->get_DocumentProperties();

    System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
    System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

V tomto režimu se nenačítá obsah snímků. Snímky, hlavní snímky, rozvržení, tvary, média a další objekty prezentace nejsou k dispozici. Aplikace by měly vždy zkontrolovat [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) před provedením operace, která vyžaduje kompletní model objektů prezentace.

{{% alert color="warning" title="Security" %}}
Veřejná metadata mohou odhalit jména autorů, názvy, předměty, klíčová slova, informace o společnosti, komentáře a vlastní hodnoty. Šifrujte citlivé vlastnosti společně s prezentací. Nechte je veřejné jen v případech, kdy indexování, klasifikace, vyhledávání nebo systémy správy dokumentů mají konkrétní požadavek na přístup k nim bez hesla.
{{% /alert %}}

## **Aktualizovat vlastnosti šifrované prezentace**

Pro šifrovaný soubor PPTX je prezentace načtená předáním `true` metodě [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) určena ke čtení veřejných metadat. Aspose.Slides nemůže uložit změněné vlastnosti z tohoto objektu obsahujícího jen metadata, protože veřejné vlastnosti musí zůstat v souladu s odpovídajícími daty v šifrované prezentaci. Aktualizace proto vyžaduje správné otevírací heslo a kompletní načtení.

Příklad vyžaduje šifrovanou PPTX prezentaci s veřejnými vlastnostmi dokumentu a známým otevíracím heslem. Otevře kompletní prezentaci pomocí [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/), aktualizuje veřejné vestavěné vlastnosti a uloží výsledek. Poté použije [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) k ověření, že šifrování je zachováno, a znovu otevře veřejná metadata bez hesla k ověření nových hodnot:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputPath = u"public-properties-encrypted.pptx";
const System::String outputPath = u"updated-public-properties-encrypted.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(inputPath, loadOptions);

auto documentProperties = presentation->get_DocumentProperties();
documentProperties->set_Title(u"Updated Product Roadmap");
documentProperties->set_Keywords(u"roadmap, planning, indexed");

presentation->Save(outputPath, SaveFormat::Pptx);

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
System::Console::WriteLine(u"The presentation is encrypted: {0}", presentationInfo->get_IsEncrypted());

auto metadataLoadOptions = System::MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = System::MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    System::Console::WriteLine(u"Title: {0}", metadataPresentation->get_DocumentProperties()->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

Pokud aplikace nemá povoleno dešifrovat nebo načíst obsah prezentace, musí veřejné vlastnosti šifrovaného souboru PPTX považovat za jen ke čtení.

## **Přístup k vestavěným vlastnostem**

Rozhraní [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) zpřístupňuje vestavěná metadata přes typované získávače, včetně [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/), [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/), a [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/). Tento příklad otevře existující prezentaci a vypíše její uložená metadata na konzoli. Hodnoty závisejí na vstupní prezentaci; některá pole mohou být prázdná.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"AccessBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

System::Console::WriteLine(u"Category: {0}", documentProperties->get_Category());
System::Console::WriteLine(u"Content status: {0}", documentProperties->get_ContentStatus());
System::Console::WriteLine(u"Creation date: {0}", documentProperties->get_CreatedTime());
System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
System::Console::WriteLine(u"Comments: {0}", documentProperties->get_Comments());
System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
System::Console::WriteLine(u"Last modified by: {0}", documentProperties->get_LastSavedBy());
System::Console::WriteLine(u"Manager: {0}", documentProperties->get_Manager());
System::Console::WriteLine(u"Modified date: {0}", documentProperties->get_LastSavedTime());
System::Console::WriteLine(u"Presentation format: {0}", documentProperties->get_PresentationFormat());
System::Console::WriteLine(u"Last print date: {0}", documentProperties->get_LastPrinted());
System::Console::WriteLine(u"Is shared between producers: {0}", documentProperties->get_SharedDoc());
System::Console::WriteLine(u"Subject: {0}", documentProperties->get_Subject());
System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
```

### **Zpráva o čísle revize a čase úprav**

Použijte [GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) a [ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) k načtení [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) každého souboru bez načtení jeho snímků pro úpravy. Tento příklad vypíše jeden řádek na každý soubor PPTX ve složce `presentations`. Standardní formát `c` zahrnuje počet dní, když zaznamenaný čas úprav dosáhne 24 hodin.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/timespan.h>

using namespace Aspose::Slides;
using namespace System::IO;

System::Console::WriteLine(u"File | RevisionNumber | TotalEditingTime");
auto paths = Directory::GetFiles(u"presentations", u"*.pptx");
for (const auto& path : paths)
{
    auto info = PresentationFactory::get_Instance()->GetPresentationInfo(path);
    auto properties = info->ReadDocumentProperties();
    auto fileName = Path::GetFileName(path);
    auto editingTime = properties->get_TotalEditingTime().ToString(u"c");
    System::Console::WriteLine(u"{0} | {1} | {2}", fileName, properties->get_RevisionNumber(), editingTime);
}
```

Pro prezentaci s 1 dnem, 2 hodinami a 5 minutami zaznamenaného času úprav vypadá zpráva takto:

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[get_RevisionNumber](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_revisionnumber/) načte hodnotu metadat, kterou aplikace mohou změnit pomocí [set_RevisionNumber](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_revisionnumber/). Tato hodnota sama o sobě nemůže určit, kolikrát byla prezentace uložena, nebo rekonstruovat její historii verzí.

[get_TotalEditingTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_totaleditingtime/) vrací dobu úpravy zaznamenanou v souboru. Hodnota `00:00:00` znamená, že uložená doba je nula. Prezentace mohla být i přesto upravována.

## **Upravit vestavěné vlastnosti**

Pro aktualizaci vestavěných metadat použijte nastavení na objektu vráceném [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). Tento příklad otevře existující prezentaci, zavolá [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/), [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/), [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/), [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/), a [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/), poté uloží aktualizovanou prezentaci pomocí [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Uložený PPTX obsahuje nová metadata.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ModifyBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->set_Author(u"Aspose.Slides for C++");
documentProperties->set_Title(u"Manage PowerPoint Presentation Properties");
documentProperties->set_Subject(u"Modify Built-in Properties");
documentProperties->set_Comments(u"Aspose description");
documentProperties->set_Manager(u"Aspose manager");

presentation->Save(u"DocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Spravovat základ hyperodkazů**

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) načte základ dokumentu pro relativní hyperodkazy. To je užitečné při přesunu prezentace a jejích propojených souborů na jiné místo. Je to oddělené od individuálního hyperodkazu [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/): změna základu nepřepíše uložené adresy odkazů ani nezmění absolutní cíle.

Příklad vyžaduje prezentaci obsahující jak relativní odkaz, např. `target.html`, tak absolutní odkaz, např. `https://example.org/absolute.html`. Načte existující základ, přiřadí novou základní adresu pomocí [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/), uloží a znovu otevře prezentaci pro kontrolu hodnoty. Poté vymaže základ pomocí `u""` a ověří prázdnou hodnotu v samostatném uloženém souboru. Nahraďte ukázkovou základní adresu umístěním vašich propojených souborů.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");

System::Console::WriteLine(u"Original base: {0}", presentation->get_DocumentProperties()->get_HyperlinkBase());

const System::String newBase = u"https://example.com/new/";
presentation->get_DocumentProperties()->set_HyperlinkBase(newBase);
presentation->Save(u"hyperlinks-updated.pptx", SaveFormat::Pptx);

auto updatedPresentation = System::MakeObject<Presentation>(u"hyperlinks-updated.pptx");
System::Console::WriteLine(u"Base preserved: {0}", (updatedPresentation->get_DocumentProperties()->get_HyperlinkBase() == newBase));

updatedPresentation->get_DocumentProperties()->set_HyperlinkBase(u"");
updatedPresentation->Save(u"hyperlinks-cleared.pptx", SaveFormat::Pptx);

auto clearedPresentation = System::MakeObject<Presentation>(u"hyperlinks-cleared.pptx");
System::Console::WriteLine(u"Base cleared: {0}", (clearedPresentation->get_DocumentProperties()->get_HyperlinkBase() == u""));
```

Dvĕ zprávy ověření by měly vypsat `True`. Vymazání základu ponechá jednotlivé adresy hyperodkazů nedotčeny.

Relativní odkaz na `target.pptx` otevřel `old/target.pptx`, když základ ukazoval na složku `old`. Po změně základu na složku `new`, uložení a opětovném otevření prezentace stejný odkaz otevřel `new/target.pptx`. Absolutní odkaz nadále otevřel stejný soubor. Otestujte své relativní odkazy v PowerPointu před a po přesunu prezentace nebo změně jejího základu.

## **Přidat vlastní vlastnosti prezentace**

Vlastní vlastnosti ukládají metadata, která nemají odpovídající vestavěné pole. [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) vám umožní přiřadit hodnotu podle názvu vlastnosti. Tento příklad vytvoří prezentaci, přidá dvě textové hodnoty a celočíselnou verzi, a uloží prezentaci pomocí [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Přiřazení hodnoty k existujícímu názvu nahradí hodnotu této vlastnosti.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->idx_set(u"Reviewed by", System::ObjectExt::Box<System::String>(u"John Smith"));
documentProperties->idx_set(u"Confidentiality level", System::ObjectExt::Box<System::String>(u"Internal"));
documentProperties->idx_set(u"Document version", System::ObjectExt::Box(2));

presentation->Save(u"CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Přístup a úprava vlastních vlastností**

Tento příklad otevře prezentaci obsahující vlastní vlastnosti a použije [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) k jejich iteraci. [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) přijímá index od nuly a vrací název používaný [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) a [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/). Příklad vypíše každý původní název a hodnotu, nahradí každou hodnotu číslovaným řetězcem bez ohledu na původní typ, a uloží změny. Pokud neexistují žádné vlastní vlastnosti, smyčka neprovede žádné změny.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"AccessAndModifyProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

for (auto i = 0; i < documentProperties->get_CountOfCustomProperties(); i++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(i);
    auto propertyValue = documentProperties->idx_get(propertyName);

    System::Console::WriteLine(u"Custom property name: {0}", propertyName);
    System::Console::WriteLine(u"Custom property value: {0}", propertyValue);

    documentProperties->idx_set(propertyName, System::ObjectExt::Box(System::String::Format(u"New Value {0}", i + 1)));
}

presentation->Save(u"CustomProperties_output.pptx", SaveFormat::Pptx);
```

## **Ukázkový příklad**

Vyzkoušejte online aplikaci [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) a podívejte se, jak pracovat s vlastnostmi dokumentu pomocí Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Často kladené dotazy**

**Jak mohu odstranit vestavěnou vlastnost z prezentace?**

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete však změnit jejich hodnoty nebo je nastavit na prázdné, pokud to konkrétní vlastnost umožňuje.

**Co se stane, když přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte vlastnost předtím odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu přistupovat k vlastnostem prezentace bez úplného načtení prezentace?**

Ano. Použijte [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) a následně [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/), abyste načetli uložená metadata dokumentu bez vytvoření instance [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). Viz [Build a Lightweight Presentation Inventory](/slides/cs/cpp/examine-presentation/) pro úplný příklad reportování a omezení specifická pro formát.

**Mohu číst veřejné vlastnosti šifrované prezentace bez jejího otevíracího hesla?**

Ano. Prezentace musí být šifrována předáním `false` metodě [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), a musí být načtena předáním `true` metodě [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/).

**Mohu aktualizovat šifrovaný soubor PPTX v režimu pouze vlastnosti dokumentu?**

Ne. Veřejná a šifrovaná data vlastností musí zůstat konzistentní, takže aktualizace šifrovaného souboru PPTX vyžaduje načtení celé prezentace s správným otevíracím heslem.