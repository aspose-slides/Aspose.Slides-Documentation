---
title: Zabezpieczanie prezentacji przed zapisem w C++
linktitle: Ochrona przed zapisem
type: docs
weight: 25
url: /pl/cpp/write-protected-presentation/
keywords:
- ochrona przed zapisem
- zabezpieczenie przed zapisem PowerPoint
- hasło do modyfikacji
- ograniczenie edycji prezentacji
- usuń ochronę przed zapisem
- weryfikacja hasła modyfikacji
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Ustawiaj, wykrywaj, weryfikuj i usuwaj hasła ochrony przed zapisem w prezentacjach PowerPoint PPT i PPTX przy użyciu Aspose.Slides dla C++."
---
## **Wprowadzenie**

Hasło zabezpieczające przed zapisem ogranicza modyfikację prezentacji, ale nie szyfruje jej treści. Użytkownicy mogą wczytać i wyświetlić prezentację chronioną przed zapisem bez podania hasła. W zależności od aplikacji mogą również edytować treść i zapisać ją pod inną nazwą, więc ochrona przed zapisem nie powinna być traktowana jako mechanizm poufności.

Hasło otwierające ma inny cel: szyfruje prezentację i jest wymagane do wczytania jej treści. Aby zaszyfrować prezentację lub zweryfikować hasło otwierające, zobacz [Password-Protect Presentations](/slides/pl/cpp/password-protected-presentation/).

Procedury opisane w tym artykule dotyczą zarówno prezentacji PPT, jak i PPTX. Przykłady używają plików PPTX; przy zapisywaniu jako PPT należy używać rozszerzenia `.ppt` oraz odpowiedniego formatu zapisu PPT.

## **Ustaw ochronę przed zapisem w prezentacji**

Użyj [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iprotectionmanager/setwriteprotection/), aby przypisać hasło do modyfikacji prezentacji. Zapisanie prezentacji zachowuje ustawienie ochrony.

Poniższy przykład ustawia ochronę przed zapisem w prezentacji PPTX:

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

## **Wczytaj prezentację chronioną przed zapisem**

Ponieważ ochrona przed zapisem nie szyfruje treści prezentacji, nie jest wymagane żadne hasło do wczytania prezentacji. Hasło jest istotne tylko przy weryfikacji uprawnień do modyfikacji chronionej prezentacji.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

Nie przekazuj hasła ochrony przed zapisem do [LoadOptions::set_Password](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_password/). Właściwość ta przyjmuje hasło otwierające dla zaszyfrowanej treści. Jeśli prezentacja posiada oba rodzaje ochrony, podaj hasło otwierające, aby ją wczytać, a hasło ochrony przed zapisem obsłuż osobno.

## **Usuń ochronę przed zapisem z prezentacji**

Użyj [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iprotectionmanager/removewriteprotection/), aby usunąć ograniczenie modyfikacji, a następnie zapisz prezentację.

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

## **Sprawdź, czy prezentacja jest chroniona przed zapisem**

Aby zbadać plik bez tworzenia pełnej instancji [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/), wywołaj [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) i sprawdź [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/). Właściwość używa [NullableBool](https://reference.aspose.com/slides/pl/cpp/aspose.slides/nullablebool/) i zwraca `NullableBool::True`, gdy wykryto ochronę przed zapisem.

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

Przeciążenie strumieniowe [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) dostarcza te same informacje dla prezentacji podanej jako strumień.

## **Zweryfikuj hasło ochrony przed zapisem**

Użyj [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/), aby zweryfikować hasło modyfikacji bez wczytywania pełnej prezentacji. Najpierw sprawdź [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/), aby aplikacja żądała lub weryfikowała hasło tylko wtedy, gdy istnieje ochrona przed zapisem.

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

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) weryfikuje tylko hasło ochrony przed zapisem. Nie weryfikuje hasła otwierającego ani nie określa, czy zaszyfrowana treść może zostać wczytana. Natomiast [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/checkpassword/) weryfikuje wyłącznie hasło otwierające. Jeśli pełna prezentacja została już wczytana, [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) zapewnia równoważną weryfikację ochrony przed zapisem poprzez jego menedżer ochrony.

W aplikacjach produkcyjnych nie zapisuj haseł w logach ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych wielokrotnych prób weryfikacji i przechowuj hasła w pamięci tylko tak długo, jak jest to konieczne.

{{% alert color="info" title="Zobacz także" %}}
- [Password-Protect Presentations](/slides/pl/cpp/password-protected-presentation/)
- [Read-Only Presentations](/slides/pl/cpp/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/pl/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Czy ochrona przed zapisem szyfruje prezentację?**

Nie. Ogranicza modyfikację, ale pozostawia treść prezentacji dostępną do wczytania i przeglądania.

**Czy hasło ochrony przed zapisem jest wymagane do otwarcia prezentacji?**

Nie. Tylko hasło otwierające jest wymagane do wczytania zaszyfrowanej treści prezentacji.

**Czy prezentacja może mieć jednocześnie hasło otwierające i hasło ochrony przed zapisem?**

Tak. Podaj hasło otwierające za pomocą opcji wczytywania, aby otworzyć zaszyfrowaną prezentację, oraz osobno zweryfikuj hasło ochrony przed zapisem, gdy wymagana jest autoryzacja do modyfikacji.