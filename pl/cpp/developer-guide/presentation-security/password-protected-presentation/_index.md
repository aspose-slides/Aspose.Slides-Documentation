---
title: Zabezpieczanie prezentacji hasłem w C++
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/cpp/password-protected-presentation/
keywords:
- prezentacja zabezpieczona hasłem
- hasło otwarcia
- szyfrowanie PowerPoint
- odszyfrowywanie PowerPoint
- walidacja hasła prezentacji
- sprawdzenie hasła prezentacji
- otwieranie zaszyfrowanej prezentacji
- usuwanie szyfrowania
- PowerPoint
- PPT
- PPTX
- prezentacja
- C++
- Aspose.Slides
description: "Szyfruj, wykrywaj, waliduj, otwieraj i odszyfrowuj prezentacje PowerPoint PPT i PPTX zabezpieczone hasłem w C++ z użyciem Aspose.Slides."
---
## **Przegląd**

Hasło otwarcia szyfruje prezentację. Poprawne hasło jest wymagane do załadowania i wyświetlenia zawartości prezentacji, dlatego ochrona ta zapewnia poufność.

Hasło otwarcia różni się od hasła ochrony przed zapisem. Ochrona przed zapisem ogranicza modyfikację, ale nie szyfruje zawartości ani nie uniemożliwia załadowania prezentacji. Aby zarządzać hasłami służącymi do modyfikacji prezentacji, zobacz [Write-Protect Presentations](/slides/pl/cpp/write-protected-presentation/).

Poniższe przepływy pracy dotyczą zarówno prezentacji PPT, jak i PPTX. Przykłady używają obu formatów, gdy istotne jest ich zachowanie oparte na plikach i strumieniach.

## **Zaszyfruj prezentację hasłem otwarcia**

Użyj [IProtectionManager::Encrypt](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iprotectionmanager/encrypt/) aby przydzielić hasło otwarcia. Następnie użyj [IPresentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/save/) aby zapisać zaszyfrowaną prezentację.

Poniższy przykład szyfruje prezentację PPTX:

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

## **Załaduj zaszyfrowaną prezentację**

Ustaw [LoadOptions::set_Password](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_password/) na hasło otwarcia i przekaż opcje do [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) podczas ładowania pliku. Ładowanie nie powiodzie się, gdy wymagane jest hasło otwarcia, a podane hasło jest brakujące lub nieprawidłowe.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Praca z odszyfrowaną prezentacją.
```

## **Usuń szyfrowanie z prezentacji**

Załaduj prezentację przy użyciu jej hasła otwarcia, wywołaj [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iprotectionmanager/removeencryption/) i zapisz wynik. Zapisana prezentacja może następnie zostać załadowana bez hasła.

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

## **Sprawdź poprawność hasła otwarcia przed załadowaniem**

Użyj [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) aby uzyskać [IPresentationInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/) bez tworzenia pełnej instancji prezentacji. Sprawdź [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) przed żądaniem lub walidacją hasła. Gdy ochrona jest obecna, zweryfikuj podaną wartość przy pomocy [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Przepływ pracy z użyciem ścieżki pliku**

Poniższy przykład weryfikuje hasło otwarcia dla pliku PPTX, przekazuje zweryfikowaną wartość do [LoadOptions::set_Password](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_password/) i następnie ładuje pełną prezentację:

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

### **Przepływ pracy ze strumieniem**

Przeciążenie strumieniowe [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) zapewnia ten sam przepływ pracy. Zresetuj pozycję strumienia, który obsługuje przeszukiwanie, przed załadowaniem pełnej prezentacji z tego strumienia.

Poniższy przykład używa pliku PPT:

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

### **Wartości zwracane przez CheckPassword**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/checkpassword/) zwraca `true` tylko wtedy, gdy prezentacja ma hasło otwarcia i podane hasło jest prawidłowe. Zwraca `false` w każdym z poniższych przypadków:

- Hasło jest nieprawidłowe.
- Prezentacja nie posiada hasła otwarcia.
- Podane hasło jest null lub puste.

Zachowanie jest identyczne dla prezentacji PPT i PPTX.

## **Sprawdź, czy załadowana prezentacja jest zaszyfrowana**

Po załadowaniu prezentacji przy użyciu poprawnego hasła sprawdź [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iprotectionmanager/get_isencrypted/), aby potwierdzić, że źródłowa prezentacja była szyfrowana. Aby wykryć ochronę hasłem otwarcia przed załadowaniem, użyj `IPresentationInfo::get_IsPasswordProtected`, jak pokazano powyżej.

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

## **Zalecenia dotyczące bezpieczeństwa**

{{% alert color="warning" title="Bezpieczeństwo" %}}
Nie rejestruj haseł otwarcia ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych powtarzających się prób walidacji, przechowuj hasła w pamięci tylko tak długo, jak jest to potrzebne, oraz ponownie używaj wyniku udanej walidacji przy natychmiastowym ładowaniu prezentacji.
{{% /alert %}}

## **Zabezpiecz prezentację hasłem online**

1. Otwórz aplikację [Aspose.Slides Lock](https://products.aspose.app/slides/pl/lock).
1. Wybierz lub prześlij prezentację.
1. Wprowadź hasło chroniące podgląd.
1. Opcjonalnie wprowadź oddzielne hasło zabezpieczające edycję.
1. Zastosuj ochronę i pobierz otrzymany plik.

{{% alert color="info" title="Zobacz także" %}}
- [Zabezpiecz przed zapisem](/slides/pl/cpp/write-protected-presentation/)
- [Podpis cyfrowy w PowerPoint](/slides/pl/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między hasłem otwarcia a hasłem ochrony przed zapisem?**

Hasło otwarcia szyfruje prezentację i jest wymagane do załadowania jej zawartości. Hasło ochrony przed zapisem ogranicza modyfikację bez szyfrowania zawartości.

**Czy mogę zweryfikować hasło otwarcia bez ładowania wszystkich slajdów?**

Tak. Uzyskaj informacje o prezentacji, sprawdź, czy istnieje ochrona hasłem otwarcia, i zweryfikuj hasło przed utworzeniem pełnej instancji prezentacji.

**Czy przepływy weryfikacji hasła obsługują zarówno PPT, jak i PPTX?**

Tak. Wykrywanie i weryfikacja hasła oparte na ścieżce pliku oraz strumieniu zachowują się identycznie dla prezentacji PPT i PPTX.