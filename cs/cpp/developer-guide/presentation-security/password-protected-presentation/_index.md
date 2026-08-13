---
title: Zabezpečení prezentací hesly v C++
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/cpp/password-protected-presentation/
keywords:
- zamknout PowerPoint
- zamknout prezentaci
- odemknout PowerPoint
- odemknout prezentaci
- chránit PowerPoint
- chránit prezentaci
- nastavit heslo
- přidat heslo
- šifrovat PowerPoint
- šifrovat prezentaci
- dešifrovat PowerPoint
- dešifrovat prezentaci
- ochrana proti zápisu
- zabezpečení PowerPoint
- zabezpečení prezentace
- odstranit heslo
- odstranit ochranu
- odstranit šifrování
- zakázat heslo
- zakázat ochranu
- odstranit ochranu proti zápisu
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Zjistěte, jak snadno zamknout a odemknout heslem chráněné PowerPoint a OpenDocument prezentace pomocí Aspose.Slides pro C++. Zabezpečte své prezentace."
---
## **Úvod**

Když heslem chráníte prezentaci, nastavujete heslo, které uplatňuje určitá omezení na prezentaci. Pro odstranění omezení je nutné zadat heslo. Prezentace chráněná heslem se považuje za zamčenou prezentaci.

Typicky můžete nastavit heslo, aby se tato omezení na prezentaci uplatnila:

- **Úprava**

  Pokud chcete, aby jen určití uživatelé mohli upravovat vaši prezentaci, můžete nastavit omezení úpravy. Toto omezení zabraňuje lidem v úpravě, změně nebo kopírování obsahu ve vaší prezentaci (pokud neposkytnou heslo).

  Nicméně v tomto případě bude uživatel i bez hesla moci přistupovat k dokumentu a otevřít jej. V režimu pouze ke čtení může uživatel zobrazit obsah nebo prvky — hyperlinky, animace, efekty a další — v prezentaci, ale nemůže kopírovat položky ani prezentaci uložit.

- **Otevření**

  Pokud chcete, aby jen určití uživatelé mohli otevřít vaši prezentaci, můžete nastavit omezení otevírání. Toto omezení zabraňuje lidem dokonce zobrazit obsah vaší prezentace (pokud neposkytnou heslo).

  Technicky omezení otevírání také zabraňuje uživatelům upravovat vaše prezentace: Když lidé nemohou prezentaci otevřít, nemohou ji upravovat ani měnit.

  **Poznámka** že když chráníte prezentaci heslem, aby se zabránilo otevírání, soubor prezentace se zašifruje.

## **Jak chránit prezentaci heslem online**

1. Přejděte na naši stránku [**Aspose.Slides Lock**](https://products.aspose.app/slides/cs/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Klikněte na **Přetáhněte nebo nahrajte své soubory**.

3. Vyberte soubor, který chcete chránit heslem, ve svém počítači.

4. Zadejte své preferované heslo pro ochranu úprav; Zadejte své preferované heslo pro ochranu zobrazení.

5. Pokud chcete, aby uživatelé viděli vaši prezentaci jako finální kopii, zaškrtněte políčko **Mark as final**.

6. Klikněte na **PROTECT NOW.**

7. Klikněte na **DOWNLOAD NOW.**

## **Ochrana heslem pro prezentace v Aspose.Slides**
**Podporované formáty**

Aspose.Slides podporuje ochranu heslem, šifrování a podobné operace pro prezentace v těchto formátech:

- PPTX a PPT – Microsoft PowerPoint prezentace
- ODP – OpenDocument prezentace
- OTP – OpenDocument šablona prezentace

**Podporované operace**

Aspose.Slides vám umožňuje použít ochranu heslem na prezentacích k zabránění úprav následujícími způsoby:

- Šifrování prezentace
- Nastavení ochrany proti zápisu na prezentaci

**Další operace**

Aspose.Slides vám umožňuje provádět další úkoly související s ochranou heslem a šifrováním následujícími způsoby:

- Dešifrování prezentace; otevření zašifrované prezentace
- Odstranění šifrování; deaktivace ochrany heslem
- Odstranění ochrany proti zápisu z prezentace
- Získání vlastností zašifrované prezentace
- Kontrola, zda je prezentace zašifrována
- Kontrola, zda je prezentace chráněna heslem.

## **Zašifrovat prezentaci**

Prezentaci můžete zašifrovat nastavením hesla. Pak uživatel musí zadat heslo, aby mohl upravit zamčenou prezentaci.

Pro zašifrování nebo ochranu heslem prezentace musíte použít metodu encrypt (z [ProtectionManager](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.protection_manager)), která nastaví heslo pro prezentaci. Heslo předáte metodě encrypt a použijete metodu save k uložení nyní zašifrované prezentace.

Tento ukázkový kód ukazuje, jak zašifrovat prezentaci:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Nastavit ochranu proti zápisu u prezentace**

Můžete k prezentaci přidat značku „Do not modify“. Tímto způsobem můžete uživatelům sdělit, že si nepřejete, aby prováděli změny v prezentaci.

**Poznámka** že proces ochrany proti zápisu nešifruje prezentaci. Proto uživatelé — pokud skutečně chtějí — mohou prezentaci upravovat, ale pro uložení změn budou muset vytvořit prezentaci pod jiným názvem.

Můžete použít metodu setWriteProtection. Tento ukázkový kód ukazuje, jak nastavit ochranu proti zápisu u prezentace:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Načíst zašifrovanou prezentaci**

Aspose.Slides vám umožňuje načíst zašifrovaný soubor zadáním jeho hesla. Pro dešifrování prezentace musíte zavolat metodu [RemoveEncryption](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) bez parametrů. Poté budete muset zadat správné heslo k načtení prezentace.

Tento ukázkový kód ukazuje, jak dešifrovat prezentaci:

``` cpp
#include <DOM/LoadOptions.h>
using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// pracovat s dešifrovanou prezentací
```

## **Odstranit šifrování z prezentace**

Můžete odstranit šifrování nebo ochranu heslem z prezentace. Tímto způsobem uživatelé získají možnost přistupovat k prezentaci nebo ji upravovat bez omezení.

Pro odstranění šifrování nebo ochrany heslem musíte zavolat metodu [RemoveEncryption](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Tento ukázkový kód ukazuje, jak odstranit šifrování z prezentace:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Odstranit ochranu proti zápisu z prezentace**

Můžete pomocí Aspose.Slides odstranit ochranu proti zápisu použité na souboru prezentace. Tímto způsobem uživatelé mohou upravovat podle libosti — a při těchto operacích nedostanou žádná varování.

Ochranu proti zápisu z prezentace můžete odstranit pomocí metody [RemoveWriteProtection](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Tento ukázkový kód ukazuje, jak odstranit ochranu proti zápisu z prezentace:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Získat vlastnosti zašifrované prezentace**

Typicky mají uživatelé potíže získat vlastnosti dokumentu zašifrované nebo chráněné heslem prezentace. Nicméně Aspose.Slides poskytuje mechanismus, který umožňuje chránit prezentaci heslem a současně umožnit přístup k jejím vlastnostem dokumentu.

**Poznámka:** Ve výchozím nastavení, když Aspose.Slides zašifruje prezentaci, jsou vlastnosti dokumentu prezentace také chráněny heslem. Pokud potřebujete, aby byly vlastnosti dokumentu přístupné i po šifrování, Aspose.Slides vám to umožňuje.

Pokud chcete, aby uživatelé zachovali možnost přístupu k vlastnostem zašifrované prezentace, předávejte `false` metodě `set_EncryptDocumentProperties` rozhraní [IProtectionManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iprotectionmanager/). Tento ukázkový kód ukazuje, jak zašifrovat prezentaci a zároveň poskytovat uživatelům přístup k jejím vlastnostem dokumentu:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Načíst jen vlastnosti dokumentu ze zašifrované prezentace**

Pro prozkoumání metadat zašifrované prezentace bez načítání jejích snímků nebo jiného obsahu vytvořte objekt [LoadOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/) a nastavte [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) na `true`. V tomto režimu Aspose.Slides ignoruje heslo a načte jen veřejně přístupné vlastnosti dokumentu.

Následující příklad kódu čte vestavěné i vlastní vlastnosti dokumentu prostřednictvím [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/get_documentproperties/):

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

Tento postup funguje jen tehdy, když byly vlastnosti dokumentu při šifrování prezentace ponechány nešifrované (veřejné). Pokud jsou vlastnosti dokumentu zašifrované, nastavení `LoadOptions::set_OnlyLoadDocumentProperties` na `true` způsobí výjimku, protože heslo je v tomto režimu ignorováno. Pro přístup k šifrovaným vlastnostem dokumentu nebo načtení celé prezentace včetně snímků a dalšího obsahu poskytněte správné heslo pomocí `LoadOptions::set_Password` v [LoadOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/).

## **Zkontrolovat, zda je prezentace chráněna heslem**

Před načtením prezentace můžete chtít zkontrolovat a potvrdit, že prezentace není chráněna heslem. Tímto způsobem se vyhnete chybám a podobným problémům, které nastanou při načtení prezentace chráněné heslem bez zadání hesla.

Tento C++ kód ukazuje, jak prozkoumat prezentaci a zjistit, zda je chráněna heslem (bez načtení samotné prezentace):

```c++
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Zkontrolovat, zda je prezentace zašifrována**

Aspose.Slides vám umožňuje zkontrolovat, zda je prezentace zašifrována. K provedení tohoto úkolu můžete použít metodu [get_IsEncrypted()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), která vrací `true`, pokud je prezentace zašifrována, nebo `false`, pokud není zašifrována.

Tento ukázkový kód ukazuje, jak zkontrolovat, zda je prezentace zašifrována:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Zkontrolovat, zda je prezentace chráněna proti zápisu**

Aspose.Slides vám umožňuje zkontrolovat, zda je prezentace chráněna proti zápisu. K provedení tohoto úkolu můžete použít metodu [get_IsWriteProtected()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), která vrací `true`, pokud je prezentace chráněna proti zápisu, nebo `false`, pokud není chráněna.

Tento ukázkový kód ukazuje, jak zkontrolovat, zda je prezentace chráněna proti zápisu:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Ověřit použití hesla k prezentaci**

Možná budete chtít zkontrolovat a potvrdit, že konkrétní heslo bylo použito k ochraně dokumentu prezentace. Aspose.Slides poskytuje prostředky k ověření hesla.

Tento ukázkový kód ukazuje, jak ověřit heslo:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// zkontrolovat, zda je "pass" shodné s
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Vrátí `true`, pokud byla prezentace zašifrována zadaným heslem. V opačném případě vrátí `false`.

{{% alert color="info" title="Viz také" %}} 
- [Digitální podpis v PowerPointu](/slides/cs/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaké šifrovací metody Aspose.Slides podporuje?**

Aspose.Slides podporuje moderní šifrovací metody, včetně algoritmů založených na AES, což zajišťuje vysokou úroveň zabezpečení dat vašich prezentací.

**Co se stane, pokud je při pokusu o otevření prezentace zadáno nesprávné heslo?**

Je vyvolána výjimka, pokud je použito nesprávné heslo, což vás upozorní, že přístup k prezentaci byl odepřen. To pomáhá zabránit neoprávněnému přístupu a chrání obsah prezentace.

**Existují nějaké dopady na výkon při práci s prezentacemi chráněnými heslem?**

Proces šifrování a dešifrování může během operací otevírání a ukládání zavést mírné zatížení. Ve většině případů je tento dopad na výkon minimální a výrazně neovlivňuje celkový čas zpracování vašich úkolů s prezentacemi.