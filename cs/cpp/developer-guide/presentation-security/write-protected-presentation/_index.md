---
title: Ochrana proti zápisu prezentací v C++
linktitle: Ochrana proti zápisu
type: docs
weight: 25
url: /cs/cpp/write-protected-presentation/
keywords:
- ochrana proti zápisu
- ochrana proti zápisu PowerPoint
- heslo pro úpravu
- omezit úpravy prezentace
- odstranit ochranu proti zápisu
- ověřit heslo pro úpravu
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Nastavujte, detekujte, ověřujte a odstraňujte hesla ochrany proti zápisu v prezentacích PowerPoint PPT a PPTX pomocí Aspose.Slides pro C++."
---
## **Úvod**

Heslo pro ochranu proti zápisu omezuje úpravu prezentace, ale nešifruje její obsah. Uživatelé mohou načíst a zobrazit prezentaci chráněnou proti zápisu bez hesla. V závislosti na aplikaci mohou také upravovat obsah a uložit jej pod jiným názvem, takže ochrana proti zápisu by neměla být považována za mechanismus důvěrnosti.

Otevírací heslo slouží k jinému účelu: šifruje prezentaci a je vyžadováno pro načtení jejího obsahu. Pro šifrování prezentace nebo ověření otevíracího hesla viz [Password-Protect Presentations](/slides/cs/cpp/password-protected-presentation/).

Postupy v tomto článku platí pro prezentace PPT i PPTX. Příklady používají soubory PPTX; při ukládání do PPT použijte příponu `.ppt` a odpovídající formát uložení PPT.

## **Nastavení ochrany proti zápisu v prezentaci**

Použijte [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) k přiřazení hesla pro úpravu prezentace. Uložení prezentace zachová nastavení ochrany.

Následující příklad nastavuje ochranu proti zápisu v prezentaci PPTX:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"modify_password");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Načtení prezentace chráněné proti zápisu**

Protože ochrana proti zápisu nešifruje obsah prezentace, pro načtení prezentace není vyžadováno žádné heslo. Heslo je relevantní pouze při ověřování oprávnění k úpravě chráněné prezentace.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

Nezadejte heslo pro ochranu proti zápisu do [LoadOptions::set_Password](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_password/). Tato vlastnost přijímá otevírací heslo pro šifrovaný obsah. Pokud má prezentace oba typy ochrany, poskytněte otevírací heslo pro její načtení a heslo ochrany proti zápisu zpracujte samostatně.

## **Odstranění ochrany proti zápisu z prezentace**

Použijte [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) k odebrání omezení úprav a poté prezentaci uložte.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"write-protected-pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Kontrola, zda je prezentace chráněna proti zápisu**

Pro prozkoumání souboru bez vytvoření kompletní instance [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) zavolejte [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) a zkontrolujte [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/). Tato vlastnost používá [NullableBool](https://reference.aspose.com/slides/cs/cpp/aspose.slides/nullablebool/) a vrací `NullableBool::True`, když je detekována ochrana proti zápisu.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() == NullableBool::True)
{
    Console::WriteLine(u"The presentation is write protected.");
}
else
{
    Console::WriteLine(u"Write protection was not detected.");
}
```

Přetížení pro stream metody [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) poskytuje stejnou informaci pro prezentaci předanou jako stream.

## **Ověření hesla ochrany proti zápisu**

Použijte [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) k ověření hesla pro úpravy bez načtení kompletní prezentace. Nejprve zkontrolujte [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/), aby aplikace požadovala nebo ověřovala heslo pouze tehdy, když je ochrana proti zápisu přítomna.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() != NullableBool::True)
{
    Console::WriteLine(u"The presentation is not write protected.");
}
else if (presentationInfo->CheckWriteProtection(u"modify_password"))
{
    Console::WriteLine(u"The write-protection password is correct.");
}
else
{
    Console::WriteLine(u"The write-protection password is incorrect.");
}
```

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) ověřuje pouze heslo ochrany proti zápisu. Neověřuje otevírací heslo ani neurčuje, zda lze načíst šifrovaný obsah. Naopak [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/checkpassword/) ověřuje pouze otevírací heslo. Pokud je již načtena kompletní prezentace, [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) poskytuje ekvivalentní kontrolu ochrany proti zápisu prostřednictvím svého správce ochrany.

V produkčních aplikacích neukládejte hesla do logů ani je nezahrnujte do diagnostických zpráv. Vyhněte se zbytečným opakovaným pokusům o ověření a uchovávejte hesla v paměti pouze po dobu, kdy jsou potřebná.

{{% alert color="info" title="See also" %}}
- [Zabezpečení prezentací heslem](/slides/cs/cpp/password-protected-presentation/)
- [Prezentace jen pro čtení](/slides/cs/cpp/read-only-presentation/)
- [Digitální podpis v PowerPointu](/slides/cs/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Šifruje ochrana proti zápisu prezentaci?**

Ne. Omezuje úpravy, ale ponechává obsah prezentace dostupný pro načtení a zobrazení.

**Je heslo pro ochranu proti zápisu vyžadováno k otevření prezentace?**

Ne. Pouze otevírací heslo je vyžadováno pro načtení šifrovaného obsahu prezentace.

**Může mít prezentace jak otevírací heslo, tak heslo ochrany proti zápisu?**

Ano. Poskytněte otevírací heslo prostřednictvím možností načtení pro otevření šifrované prezentace a heslo ochrany proti zápisu ověřujte samostatně, když je vyžadováno oprávnění k úpravám.