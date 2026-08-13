---
title: Zabezpiecz prezentacje hasłami w C++
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/cpp/password-protected-presentation/
keywords:
- Zablokuj PowerPoint
- Zablokuj prezentację
- Odblokuj PowerPoint
- Odblokuj prezentację
- Chroń PowerPoint
- Chroń prezentację
- Ustaw hasło
- Dodaj hasło
- Zaszyfruj PowerPoint
- Zaszyfruj prezentację
- Odszyfruj PowerPoint
- Odszyfruj prezentację
- Ochrona przed zapisem
- Bezpieczeństwo PowerPoint
- Bezpieczeństwo prezentacji
- Usuń hasło
- Usuń ochronę
- Usuń szyfrowanie
- Wyłącz hasło
- Wyłącz ochronę
- Usuń ochronę przed zapisem
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak łatwo blokować i odblokowywać prezentacje PowerPoint i OpenDocument zabezpieczone hasłem za pomocą Aspose.Slides dla C++. Zabezpiecz swoje prezentacje."
---
## **Wprowadzenie**

Gdy zabezpieczasz prezentację hasłem, ustawiasz hasło, które egzekwuje określone ograniczenia na prezentację. Aby usunąć ograniczenia, należy podać hasło. Prezentacja zabezpieczona hasłem jest uznawana za zablokowaną prezentację.

Zazwyczaj możesz ustawić hasło, aby wymusić te ograniczenia na prezentacji:

- **Modification**

  Jeśli chcesz, aby tylko wybrani użytkownicy mogli modyfikować Twoją prezentację, możesz ustawić ograniczenie modyfikacji. To ograniczenie zapobiega ludziom modyfikowanie, zmienianie lub kopiowanie elementów w Twojej prezentacji (chyba że podadzą hasło).

  Jednak w tym przypadku, nawet bez hasła, użytkownik będzie mógł uzyskać dostęp do dokumentu i otworzyć go. W trybie tylko do odczytu użytkownik może przeglądać zawartość, taką jak hiperłącza, animacje, efekty i inne, wewnątrz prezentacji, ale nie może kopiować elementów ani zapisywać prezentacji.

- **Opening**

  Jeśli chcesz, aby tylko wybrani użytkownicy mogli otworzyć Twoją prezentację, możesz ustawić ograniczenie otwierania. To ograniczenie zapobiega ludziom nawet przeglądaniu zawartości prezentacji (chyba że podadzą hasło).

  Technicznie, ograniczenie otwierania również uniemożliwia użytkownikom modyfikację prezentacji: gdy ludzie nie mogą otworzyć prezentacji, nie mogą jej modyfikować ani wprowadzać zmian.

  **Uwaga** że gdy zabezpieczasz prezentację hasłem, aby uniemożliwić jej otwarcie, plik prezentacji staje się zaszyfrowany.

## **Jak zabezpieczyć prezentację hasłem online**

1. Przejdź do naszej strony [**Aspose.Slides Lock**](https://products.aspose.app/slides/pl/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Kliknij **Przeciągnij lub prześlij pliki**.

3. Wybierz plik, który chcesz zabezpieczyć hasłem, na swoim komputerze.

4. Wprowadź preferowane hasło dla ochrony edycji; Wprowadź preferowane hasło dla ochrony podglądu.

5. Jeśli chcesz, aby użytkownicy widzieli Twoją prezentację jako ostateczną wersję, zaznacz pole wyboru **Mark as final**.

6. Kliknij **PROTECT NOW.**

7. Kliknij **DOWNLOAD NOW.**

## **Ochrona hasłem prezentacji w Aspose.Slides**
**Obsługiwane formaty**

Aspose.Slides obsługuje ochronę hasłem, szyfrowanie i podobne operacje dla prezentacji w tych formatach:

- PPTX and PPT - Microsoft PowerPoint Presentation
- ODP - OpenDocument Presentation
- OTP -  OpenDocument Presentation Template

**Obsługiwane operacje**

Aspose.Slides umożliwia użycie ochrony hasłem na prezentacjach w celu zapobiegania modyfikacjom na następujące sposoby:

- Szyfrowanie prezentacji
- Ustawianie ochrony przed zapisem w prezentacji

**Inne operacje**

Aspose.Slides umożliwia wykonywanie innych zadań związanych z ochroną hasłem i szyfrowaniem w następujący sposób:

- Odszyfrowywanie prezentacji; otwieranie zaszyfrowanej prezentacji
- Usuwanie szyfrowania; wyłączanie ochrony hasłem
- Usuwanie ochrony przed zapisem z prezentacji
- Pobieranie właściwości zaszyfrowanej prezentacji
- Sprawdzanie, czy prezentacja jest zaszyfrowana
- Sprawdzanie, czy prezentacja jest zabezpieczona hasłem.

## **Szyfrowanie prezentacji**

Możesz zaszyfrować prezentację, ustawiając hasło. Następnie, aby zmodyfikować zablokowaną prezentację, użytkownik musi podać hasło.

Aby zaszyfrować lub zabezpieczyć prezentację hasłem, musisz użyć metody encrypt (z [ProtectionManager](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.protection_manager)), aby ustawić hasło dla prezentacji. Przekazujesz hasło do metody encrypt i używasz metody save, aby zapisać teraz zaszyfrowaną prezentację.

Ten przykładowy kod pokazuje, jak zaszyfrować prezentację:

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

## **Ustaw ochronę przed zapisem w prezentacji**

Możesz dodać znak „Nie modyfikować” do prezentacji. W ten sposób informujesz użytkowników, że nie chcesz, aby wprowadzali zmiany w prezentacji.

**Uwaga** że proces ochrony przed zapisem nie szyfruje prezentacji. Dlatego użytkownicy — jeśli naprawdę chcą — mogą modyfikować prezentację, ale aby zapisać zmiany, będą musieli utworzyć prezentację pod inną nazwą.

Aby ustawić ochronę przed zapisem, musisz użyć metody setWriteProtection. Ten przykładowy kod pokazuje, jak ustawić ochronę przed zapisem w prezentacji:

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

## **Ładowanie zaszyfrowanej prezentacji**

Aspose.Slides umożliwia załadowanie zaszyfrowanego pliku, podając jego hasło. Aby odszyfrować prezentację, musisz wywołać metodę [RemoveEncryption](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) bez parametrów. Następnie będziesz musiał wprowadzić prawidłowe hasło, aby załadować prezentację.

Ten przykładowy kod pokazuje, jak odszyfrować prezentację:

``` cpp
#include <DOM/LoadOptions.h>
using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// pracuj z odszyfrowaną prezentacją
```

## **Usunięcie szyfrowania z prezentacji**

Możesz usunąć szyfrowanie lub ochronę hasłem z prezentacji. W ten sposób użytkownicy mogą uzyskać dostęp do prezentacji lub ją modyfikować bez ograniczeń.

Aby usunąć szyfrowanie lub ochronę hasłem, musisz wywołać metodę [RemoveEncryption](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Ten przykładowy kod pokazuje, jak usunąć szyfrowanie z prezentacji:

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

## **Usunięcie ochrony przed zapisem z prezentacji**

Możesz użyć Aspose.Slides do usunięcia ochrony przed zapisem zastosowanej w pliku prezentacji. W ten sposób użytkownicy mogą modyfikować ją dowolnie — bez ostrzeżeń przy wykonywaniu takich działań.

Możesz usunąć ochronę przed zapisem z prezentacji, używając metody [RemoveWriteProtection](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Ten przykładowy kod pokazuje, jak usunąć ochronę przed zapisem z prezentacji:

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

## **Pobranie właściwości zaszyfrowanej prezentacji**

Zazwyczaj użytkownicy mają trudności z pobraniem właściwości dokumentu zaszyfrowanej lub zabezpieczonej hasłem prezentacji. Jednak Aspose.Slides udostępnia mechanizm, który pozwala zabezpieczyć prezentację hasłem, jednocześnie umożliwiając dostęp do jej właściwości dokumentu.

**Uwaga:** Domyślnie, gdy Aspose.Slides szyfruje prezentację, jej właściwości dokumentu są również chronione hasłem. Jeśli potrzebujesz, aby właściwości dokumentu były dostępne nawet po szyfrowaniu, Aspose.Slides umożliwia właśnie to.

Jeśli chcesz, aby użytkownicy zachowali możliwość dostępu do właściwości zaszyfrowanej prezentacji, przekaż `false` do metody `set_EncryptDocumentProperties` interfejsu [IProtectionManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iprotectionmanager/). Ten przykładowy kod pokazuje, jak zaszyfrować prezentację, jednocześnie udostępniając użytkownikom dostęp do jej właściwości dokumentu:

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

## **Ładowanie wyłącznie właściwości dokumentu z zaszyfrowanej prezentacji**

Aby przejrzeć metadane zaszyfrowanej prezentacji bez ładowania jej slajdów lub innej zawartości, utwórz obiekt [LoadOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/) i ustaw [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) na `true`. W tym trybie Aspose.Slides ignoruje hasło i ładuje tylko właściwości dokumentu, które są publicznie dostępne.

Poniższy przykład kodu odczytuje wbudowane i niestandardowe właściwości dokumentu za pomocą [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/get_documentproperties/):

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

Ten przepływ pracy działa tylko wtedy, gdy właściwości dokumentu pozostały niezaszyfrowane (publiczne) w momencie szyfrowania prezentacji. Jeśli właściwości dokumentu są zaszyfrowane, ustawienie `LoadOptions::set_OnlyLoadDocumentProperties` na `true` powoduje wyjątek, ponieważ w tym trybie hasło jest ignorowane. Aby uzyskać dostęp do zaszyfrowanych właściwości dokumentu lub załadować pełną prezentację, w tym jej slajdy i inną zawartość, podaj prawidłowe hasło przy użyciu `LoadOptions::set_Password` w [LoadOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/).

## **Sprawdzenie, czy prezentacja jest zabezpieczona hasłem**

Zanim załadujesz prezentację, możesz chcieć sprawdzić i potwierdzić, że nie została zabezpieczona hasłem. Dzięki temu unikniesz błędów i podobnych problemów, które pojawiają się, gdy prezentacja zabezpieczona hasłem jest ładowana bez podania hasła.

Ten kod C++ pokazuje, jak zbadać prezentację, aby sprawdzić, czy jest zabezpieczona hasłem (bez ładowania samej prezentacji):

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

## **Sprawdzenie, czy prezentacja jest zaszyfrowana**

Aspose.Slides umożliwia sprawdzenie, czy prezentacja jest zaszyfrowana. Aby wykonać to zadanie, możesz użyć metody [get_IsEncrypted()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), która zwraca `true`, jeśli prezentacja jest zaszyfrowana, lub `false`, jeśli nie jest zaszyfrowana.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest zaszyfrowana:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Sprawdzenie, czy prezentacja jest chroniona przed zapisem**

Aspose.Slides umożliwia sprawdzenie, czy prezentacja jest chroniona przed zapisem. Aby wykonać to zadanie, możesz użyć metody [get_IsWriteProtected()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), która zwraca `true`, jeśli prezentacja jest chroniona przed zapisem, lub `false`, jeśli nie jest chroniona.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest chroniona przed zapisem:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Zweryfikowanie użycia hasła w prezentacji**

Możesz chcieć sprawdzić i potwierdzić, że określone hasło zostało użyte do zabezpieczenia dokumentu prezentacji. Aspose.Slides udostępnia narzędzia do weryfikacji hasła.

Ten przykładowy kod pokazuje, jak zweryfikować hasło:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// sprawdź, czy "pass" jest dopasowane
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Zwraca `true`, jeśli prezentacja została zaszyfrowana przy użyciu podanego hasła. W przeciwnym razie zwraca `false`.

{{% alert color="info" title="Zobacz także" %}} 
- [Digital Signature in PowerPoint](/slides/pl/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jakie metody szyfrowania są obsługiwane przez Aspose.Slides?**

Aspose.Slides obsługuje nowoczesne metody szyfrowania, w tym algorytmy oparte na AES, zapewniając wysoki poziom bezpieczeństwa danych Twoich prezentacji.

**Co się stanie, jeśli podczas próby otwarcia prezentacji zostanie wprowadzone nieprawidłowe hasło?**

Zostaje wygenerowany wyjątek, jeśli użyto nieprawidłowego hasła, informując, że dostęp do prezentacji został odmówiony. Pomaga to zapobiegać nieautoryzowanemu dostępowi i chroni zawartość prezentacji.

**Czy istnieją wpływy na wydajność podczas pracy z prezentacjami zabezpieczonymi hasłem?**

Szyfrowanie i odszyfrowywanie może wprowadzić niewielkie obciążenie podczas operacji otwierania i zapisywania. W większości przypadków wpływ na wydajność jest minimalny i nie wpływa znacząco na całkowity czas przetwarzania zadań związanych z prezentacjami.