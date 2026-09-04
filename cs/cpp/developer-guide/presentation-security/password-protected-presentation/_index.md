---
title: Ochrana prezentací heslem v C++
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/cpp/password-protected-presentation/
keywords:
- prezentace chráněná heslem
- otevírací heslo
- šifrovat PowerPoint
- dešifrovat PowerPoint
- ověřit heslo prezentace
- zkontrolovat heslo prezentace
- otevřít šifrovanou prezentaci
- odstranit šifrování
- PowerPoint
- PPT
- PPTX
- prezentace
- C++
- Aspose.Slides
description: "Šifrovat, detekovat, ověřovat, otevírat a dešifrovat prezentace PowerPoint PPT a PPTX chráněné heslem v C++ pomocí Aspose.Slides."
---
## **Přehled**

Otevírací heslo šifruje prezentaci. Správné heslo je vyžadováno pro načtení a zobrazení obsahu prezentace, takže tato ochrana poskytuje důvěrnost.

Otevírací heslo se liší od hesla pro ochranu proti zápisu. Ochrana proti zápisu omezuje úpravy, ale nešifruje obsah ani nebrání načtení prezentace. Pro správu hesel pro úpravu prezentací viz [Write-Protect Presentations](/slides/cs/cpp/write-protected-presentation/).

Níže uvedené pracovní postupy platí jak pro PPT, tak pro PPTX prezentace. Příklady používají oba formáty, kde je důležité chování založené na souboru i na proudu.

## **Šifrování prezentace otevíracím heslem**

Použijte [IProtectionManager::Encrypt](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iprotectionmanager/encrypt/) k přiřazení otevíracího hesla. Poté použijte [IPresentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/save/) k uložení šifrované prezentace.

Následující příklad šifruje PPTX prezentaci:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Ponechat vlastnosti dokumentu veřejné**

Ve výchozím nastavení Aspose.Slides zahrnuje vlastnosti dokumentu do šifrování prezentace. [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) řídí toto chování nezávisle na šifrování obsahu snímků. Před voláním [IProtectionManager::Encrypt](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iprotectionmanager/encrypt/) předávejte této metodě hodnotu `false`, pokud musí systém pro indexování, klasifikaci, vyhledávání nebo správu dokumentů číst metadata bez otevíracího hesla.

Následující příklad vytvoří šifrovanou PPTX prezentaci a ponechá její vestavěné vlastnosti dokumentu veřejné:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto properties = presentation->get_DocumentProperties();
properties->set_Author(u"Contoso Knowledge Management");
properties->set_Title(u"Quarterly Product Roadmap");
properties->set_Keywords(u"roadmap, planning, internal");

presentation->get_Slide(0)->set_Name(u"Encrypted presentation content");
presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"public-properties-encrypted.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Předání `false` metodě `set_EncryptDocumentProperties` nezpřístupní veřejně snímky, předlohy, rozvržení, tvary, média ani jiný obsah prezentace. Ovlivňuje pouze vlastnosti dokumentu. Pro čtení těchto vlastností bez načítání šifrovaného obsahu viz [Manage Presentation Properties](/slides/cs/cpp/presentation-properties/).

## **Načtení šifrované prezentace**

Nastavte [LoadOptions::set_Password](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_password/) na otevírací heslo a předávejte možnosti konstruktoru [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) při načítání souboru. Načtení selže, pokud je požadováno otevírací heslo, ale zadané heslo chybí nebo je nesprávné.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Pracujte s dešifrovanou prezentací.
```

## **Odstranění šifrování z prezentace**

Načtěte prezentaci s jejím otevíracím heslem, zavolejte [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iprotectionmanager/removeencryption/) a výsledek uložte. Uložená prezentace pak může být načtena bez hesla.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Ověření otevíracího hesla před načtením**

Použijte [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) k získání [IPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/) bez vytváření kompletní instance prezentace. Před požádáním o heslo nebo jeho ověřením zkontrolujte [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/). Pokud je ochrana přítomna, ověřte zadanou hodnotu pomocí [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Pracovní postup s cestou k souboru**

Následující příklad ověří otevírací heslo pro soubor PPTX, předá ověřenou hodnotu metodě [LoadOptions::set_Password](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_password/) a poté načte kompletní prezentaci:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

String filePath = u"protected-presentation.pptx";
String password = u"open_password";
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(filePath, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Pracovní postup s proudem**

Přetížení proudu metody [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) poskytuje stejný pracovní postup. Před načtením kompletní prezentace z tohoto proudu obnovte pozici vyhledávatelného proudu.

Následující příklad používá soubor PPT:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

String password = u"open_password";
auto presentationStream = File::OpenRead(u"protected-presentation.ppt");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(presentationStream);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    presentationStream->set_Position(0);

    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(presentationStream, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Návratové hodnoty CheckPassword**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/checkpassword/) vrací `true` pouze tehdy, když má prezentace otevírací heslo a zadané heslo je správné. Vrací `false` v každém z následujících případů:

- Heslo je nesprávné.
- Prezentace nemá otevírací heslo.
- Zadané heslo je `null` nebo prázdné.

Chování je stejné pro PPT i PPTX prezentace.

## **Kontrola, zda je načtená prezentace šifrována**

Po načtení prezentace se správným heslem zkontrolujte [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iprotectionmanager/get_isencrypted/), aby jste potvrdili, že původní prezentace byla šifrována. Pro detekci ochrany otevíracím heslem před načtením použijte `IPresentationInfo::get_IsPasswordProtected`, jak je ukázáno výše.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");
auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
Console::WriteLine(isEncrypted ? u"The presentation is encrypted." : u"The presentation is not encrypted.");
```

## **Bezpečnostní doporučení**

{{% alert color="warning" title="Zabezpečení" %}}
Nezapisujte otevírací hesla do logů ani je nezahrnujte do diagnostických zpráv. Vyvarujte se zbytečných opakovaných pokusů o ověření, držte hesla v paměti jen po nezbytně nutnou dobu a opakovaně použijte úspěšný výsledek ověření při okamžitém načítání prezentace.

Veřejné vlastnosti dokumentu mohou prozradit jména autorů, názvy, předměty, klíčová slova, informace o společnosti, komentáře a vlastní hodnoty, i když je obsah prezentace šifrován. Šifrujte citlivá metadata spolu s prezentací. Ponechání vlastností veřejných by mělo být explicitním rozhodnutím, učiněným pouze v případě, že systémy musí indexovat, klasifikovat, vyhledávat nebo spravovat soubor bez otevíracího hesla.
{{% /alert %}}

## **Zamknutí prezentace heslem online**

1. Otevřete aplikaci [Aspose.Slides Lock](https://products.aspose.app/slides/cs/lock).
1. Vyberte nebo nahrajte prezentaci.
1. Zadejte heslo pro ochranu při prohlížení.
1. Volitelně zadejte samostatné heslo pro ochranu při úpravě.
1. Použijte ochranu a stáhněte výsledný soubor.

{{% alert color="info" title="Viz také" %}}
- [Write-Protect Presentations](/slides/cs/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/cs/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Časté otázky**

**Jaký je rozdíl mezi otevíracím heslem a heslem pro ochranu proti zápisu?**

Otevírací heslo šifruje prezentaci a je vyžadováno pro načtení jejího obsahu. Heslo pro ochranu proti zápisu omezuje úpravy bez šifrování obsahu.

**Mohu ověřit otevírací heslo bez načtení všech snímků?**

Ano. Získejte informace o prezentaci, zjistěte, zda je přítomna ochrana otevíracím heslem, a ověřte heslo před vytvořením kompletní instance prezentace.

**Může aplikace číst metadata bez otevíracího hesla?**

Ano, ale pouze pokud byla prezentace šifrována s `set_EncryptDocumentProperties(false)`. Aplikace pak musí použít režim načítání pouze vlastností dokumentu popsaný v [Manage Presentation Properties](/slides/cs/cpp/presentation-properties/).

**Podporují pracovní postupy pro kontrolu hesla jak PPT, tak PPTX?**

Ano. Detekce a ověření hesla na základě cesty k souboru i proudu se chovají stejně pro PPT i PPTX prezentace.