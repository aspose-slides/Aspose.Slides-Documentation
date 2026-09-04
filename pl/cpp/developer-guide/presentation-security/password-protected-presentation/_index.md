---
title: Prezentacje zabezpieczone hasłem w C++
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/cpp/password-protected-presentation/
keywords:
- prezentacja zabezpieczona hasłem
- hasło otwierające
- szyfrowanie PowerPoint
- odszyfrowywanie PowerPoint
- weryfikacja hasła prezentacji
- sprawdzanie hasła prezentacji
- otwieranie zaszyfrowanej prezentacji
- usuwanie szyfrowania
- PowerPoint
- PPT
- PPTX
- prezentacja
- C++
- Aspose.Slides
description: "Szyfruj, wykrywaj, weryfikuj, otwieraj i odszyfrowuj prezentacje PowerPoint PPT i PPTX zabezpieczone hasłem w języku C++ przy użyciu Aspose.Slides."
---
## **Przegląd**

Hasło otwierające szyfruje prezentację. Poprawne hasło jest wymagane do załadowania i wyświetlenia zawartości prezentacji, więc to zabezpieczenie zapewnia poufność.

Hasło otwierające różni się od hasła zabezpieczającego przed zapisem. Zabezpieczenie przed zapisem ogranicza możliwość modyfikacji, ale nie szyfruje zawartości ani nie uniemożliwia załadowania prezentacji. Aby zarządzać hasłami służącymi do modyfikacji prezentacji, zobacz [Zabezpiecz przed zapisem prezentacje](/slides/pl/cpp/write-protected-presentation/).

Poniższe scenariusze dotyczą zarówno prezentacji PPT, jak i PPTX. Przykłady używają obu formatów, gdy istotne są zachowania oparte na plikach i strumieniach.

## **Zaszyfruj prezentację hasłem otwierającym**

Użyj [IProtectionManager::Encrypt](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iprotectionmanager/encrypt/) aby przypisać hasło otwierające. Następnie użyj [IPresentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/save/) aby zapisać zaszyfrowaną prezentację.

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

## **Utrzymaj właściwości dokumentu publiczne**

Domyślnie Aspose.Slides dołącza właściwości dokumentu do szyfrowania prezentacji. [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) kontroluje to zachowanie niezależnie od szyfrowania zawartości slajdów. Przekaż `false` do tej metody przed wywołaniem [IProtectionManager::Encrypt](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iprotectionmanager/encrypt/) gdy system indeksowania, klasyfikacji, wyszukiwania lub zarządzania dokumentami musi odczytać metadane bez hasła otwierającego.

Poniższy przykład tworzy zaszyfrowaną prezentację PPTX, pozostawiając wbudowane właściwości dokumentu publiczne:

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

Przekazanie `false` do `set_EncryptDocumentProperties` nie udostępnia slajdów, wzorców, układów, kształtów, multimediów ani innej zawartości prezentacji. Dotyczy to wyłącznie właściwości dokumentu. Aby odczytać te właściwości bez ładowania zaszyfrowanej zawartości, zobacz [Zarządzaj właściwościami prezentacji](/slides/pl/cpp/presentation-properties/).

## **Wczytaj zaszyfrowaną prezentację**

Ustaw [LoadOptions::set_Password](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_password/) na hasło otwierające i przekaż opcje do [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) podczas ładowania pliku. Ładowanie nie powiedzie się, gdy wymagane jest hasło otwierające, a podane hasło jest brakujące lub nieprawidłowe.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Pracuj z odszyfrowaną prezentacją.
```

## **Usuń szyfrowanie z prezentacji**

Wczytaj prezentację z jej hasłem otwierającym, wywołaj [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iprotectionmanager/removeencryption/) i zapisz wynik. Zapisana prezentacja może być następnie wczytana bez hasła.

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

## **Zweryfikuj hasło otwierające przed wczytaniem**

Użyj [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) aby uzyskać [IPresentationInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/) bez tworzenia pełnej instancji prezentacji. Sprawdź [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) przed żądaniem lub weryfikacją hasła. Gdy ochrona jest obecna, zweryfikuj podaną wartość przy pomocy [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Procedura przy użyciu ścieżki pliku**

Poniższy przykład weryfikuje hasło otwierające dla pliku PPTX, przekazuje zwalidowaną wartość do [LoadOptions::set_Password](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_password/) i następnie wczytuje pełną prezentację:

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

### **Procedura strumieniowa**

Przeciążenie strumieniowe [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) zapewnia ten sam przepływ. Zresetuj pozycję strumienia z możliwością przeszukiwania przed wczytaniem pełnej prezentacji z tego strumienia.

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

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/checkpassword/) zwraca `true` tylko wtedy, gdy prezentacja posiada hasło otwierające i podane hasło jest prawidłowe. Zwraca `false` w każdym z następujących przypadków:

- Hasło jest nieprawidłowe.
- Prezentacja nie posiada hasła otwierającego.
- Podane hasło jest `null` lub puste.

Zachowanie jest identyczne dla prezentacji PPT i PPTX.

## **Sprawdź, czy wczytana prezentacja jest zaszyfrowana**

Po wczytaniu prezentacji z prawidłowym hasłem, sprawdź [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) aby potwierdzić, że źródłowa prezentacja była szyfrowana. Aby wykryć ochronę hasłem otwierającym przed wczytaniem, użyj `IPresentationInfo::get_IsPasswordProtected` jak pokazano powyżej.

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
Nie rejestruj haseł otwierających ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych wielokrotnych prób weryfikacji, przechowuj hasła w pamięci tylko tak długo, jak jest to potrzebne, i ponownie używaj udanego wyniku weryfikacji przy natychmiastowym wczytywaniu prezentacji.

Publiczne właściwości dokumentu mogą ujawnić nazwiska autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze i wartości niestandardowe, mimo że zawartość prezentacji jest zaszyfrowana. Zaszyfruj wrażliwe metadane razem z prezentacją. Pozostawienie właściwości publicznych powinno być świadomą decyzją podjętą wyłącznie wtedy, gdy systemy muszą indeksować, klasyfikować, wyszukiwać lub zarządzać plikiem bez hasła otwierającego.
{{% /alert %}}

## **Zabezpiecz prezentację hasłem online**

1. Otwórz aplikację [Aspose.Slides Lock](https://products.aspose.app/slides/pl/lock).
2. Wybierz lub prześlij prezentację.
3. Wprowadź hasło zabezpieczające podgląd.
4. Opcjonalnie wprowadź osobne hasło zabezpieczające edycję.
5. Zastosuj ochronę i pobierz powstały plik.

{{% alert color="info" title="Zobacz także" %}}
- [Zabezpiecz przed zapisem prezentacje](/slides/pl/cpp/write-protected-presentation/)
- [Podpis cyfrowy w PowerPoint](/slides/pl/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między hasłem otwierającym a hasłem zabezpieczającym przed zapisem?**

Hasło otwierające szyfruje prezentację i jest wymagane do wczytania jej zawartości. Hasło zabezpieczające przed zapisem ogranicza modyfikację bez szyfrowania zawartości.

**Czy mogę zweryfikować hasło otwierające bez wczytywania wszystkich slajdów?**

Tak. Pobierz informacje o prezentacji, sprawdź, czy ochrona hasłem otwierającym jest obecna, i zweryfikuj hasło przed utworzeniem pełnej instancji prezentacji.

**Czy aplikacja może odczytać metadane bez hasła otwierającego?**

Tak, ale tylko wtedy, gdy prezentacja została zaszyfrowana przy użyciu `set_EncryptDocumentProperties(false)`. Aplikacja musi wtedy użyć trybu ładowania wyłącznie właściwości dokumentu opisanego w [Zarządzaj właściwościami prezentacji](/slides/pl/cpp/presentation-properties/).

**Czy scenariusze sprawdzania hasła obsługują zarówno PPT, jak i PPTX?**

Tak. Wykrywanie i weryfikacja hasła oparte na ścieżce pliku oraz strumieniu zachowują się identycznie dla prezentacji PPT i PPTX.