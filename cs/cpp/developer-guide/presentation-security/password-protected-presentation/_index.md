---
title: Prezentace chráněné heslem v C++
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
description: "Šifrujte, detekujte, ověřujte, otevírejte a dešifrujte prezentace PowerPoint PPT a PPTX chráněné heslem v C++ pomocí Aspose.Slides."
---
## **Přehled**

Otevírací heslo šifruje prezentaci. Správné heslo je vyžadováno k načtení a zobrazení obsahu prezentace, takže tato ochrana poskytuje důvěrnost.

Otevírací heslo se liší od hesla pro ochranu proti zápisu. Ochrana proti zápisu omezuje úpravy, ale nešifruje obsah ani nebrání načtení prezentace. Pro správu hesel pro úpravu prezentací viz [Write-Protect Presentations](/slides/cs/cpp/write-protected-presentation/).

Níže uvedené postupy platí pro prezentace ve formátech PPT i PPTX. Příklady používají oba formáty tam, kde je důležité chování založené na souborech i na streamech.

## **Šifrování prezentace pomocí otevíracího hesla**

Použijte [IProtectionManager::Encrypt](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iprotectionmanager/encrypt/) k přiřazení otevíracího hesla. Poté použijte [IPresentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/save/) k uložení šifrované prezentace.

Následující příklad šifruje prezentaci PPTX:

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

## **Načtení šifrované prezentace**

Nastavte [LoadOptions::set_Password](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_password/) na otevírací heslo a předávejte možnosti do [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) při načítání souboru. Načtení selže, pokud je vyžadováno otevírací heslo, ale dodané heslo chybí nebo je nesprávné.

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

Načtěte prezentaci s jejím otevíracím heslem, zavolejte [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iprotectionmanager/removeencryption/) a uložte výsledek. Uloženou prezentaci lze poté načíst bez hesla.

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

Použijte [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) k získání [IPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/) bez vytvoření kompletní instance prezentace. Zkontrolujte [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) před požádáním o heslo nebo jeho ověřením. Pokud je ochrana přítomna, ověřte zadanou hodnotu pomocí [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Postup pomocí cesty k souboru**

Následující příklad ověřuje otevírací heslo pro soubor PPTX, předává ověřenou hodnotu do [LoadOptions::set_Password](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_password/) a poté načítá kompletní prezentaci:

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

### **Postup se streamem**

Přetížení pro stream metody [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) poskytuje stejný postup. Před načtením kompletní prezentace ze streamu resetujte pozici vyhledatelného (seekable) streamu.

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
- Zadané heslo je null nebo prázdné.

Chování je stejné pro prezentace PPT i PPTX.

## **Ověření, zda je načtená prezentace šifrována**

Po načtení prezentace se správným heslem zkontrolujte [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iprotectionmanager/get_isencrypted/), abyste potvrdili, že zdrojová prezentace byla šifrována. Pro detekci ochrany otevíracím heslem před načtením použijte `IPresentationInfo::get_IsPasswordProtected`, jak je uvedeno výše.

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

## **Doporučení pro zabezpečení**

{{% alert color="warning" title="Security" %}}
Nezaznamenávejte otevírací hesla ani je neuvádějte v diagnostických zprávách. Vyhněte se zbytečným opakovaným pokusům o ověření, uchovávejte hesla v paměti jen po dobu, kdy jsou potřeba, a při okamžitém načtení prezentace znovu použijte úspěšný výsledek ověření.
{{% /alert %}}

## **Ochrana prezentace heslem online**

1. Otevřete aplikaci [Aspose.Slides Lock](https://products.aspose.app/slides/cs/lock).
2. Vyberte nebo nahrajte prezentaci.
3. Zadejte heslo pro ochranu při prohlížení.
4. Volitelně zadejte samostatné heslo pro ochranu úprav.
5. Aplikujte ochranu a stáhněte výsledný soubor.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/cs/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/cs/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jaký je rozdíl mezi otevíracím heslem a heslem pro ochranu proti zápisu?**

Otevírací heslo šifruje prezentaci a je vyžadováno k načtení jejího obsahu. Heslo pro ochranu proti zápisu omezuje úpravy bez šifrování obsahu.

**Mohu ověřit otevírací heslo, aniž bych načetl všechny snímky?**

Ano. Získejte informace o prezentaci, ověřte, zda je přítomna ochrana otevíracím heslem, a heslo ověřte před vytvořením kompletní instance prezentace.

**Podporují postupy ověřování hesla jak PPT, tak PPTX?**

Ano. Detekce a ověřování hesla na základě cesty k souboru i streamu se chovají stejně pro prezentace PPT i PPTX.