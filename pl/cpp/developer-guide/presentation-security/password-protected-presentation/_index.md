---
title: Zabezpiecz prezentacje hasłem w C++
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/cpp/password-protected-presentation/
keywords:
- zablokuj PowerPoint
- zablokuj prezentację
- odblokuj PowerPoint
- odblokuj prezentację
- zabezpiecz PowerPoint
- zabezpiecz prezentację
- ustaw hasło
- dodaj hasło
- zaszyfruj PowerPoint
- zaszyfruj prezentację
- odszyfruj PowerPoint
- odszyfruj prezentację
- ochrona przed zapisem
- bezpieczeństwo PowerPoint
- bezpieczeństwo prezentacji
- usuń hasło
- usuń ochronę
- usuń szyfrowanie
- wyłącz hasło
- wyłącz ochronę
- usuń ochronę przed zapisem
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak w prosty sposób blokować i odblokowywać hasłem chronione prezentacje PowerPoint i OpenDocument przy użyciu Aspose.Slides dla C++. Zabezpiecz swoje prezentacje."
---
## **Wstęp**

Kiedy zabezpieczasz prezentację hasłem, ustawiasz hasło, które wymusza określone ograniczenia na prezentacji. Aby usunąć ograniczenia, trzeba wprowadzić hasło. Prezentacja chroniona hasłem jest uważana za zablokowaną prezentację.

Zazwyczaj możesz ustawić hasło, aby wymusić te ograniczenia na prezentacji:

- **Modyfikacja**

  Jeśli chcesz, aby tylko wybrani użytkownicy mogli modyfikować Twoją prezentację, możesz ustawić ograniczenie modyfikacji. Ograniczenie to uniemożliwia osobom modyfikowanie, zmianę lub kopiowanie elementów w Twojej prezentacji (chyba że podadzą hasło).

  Jednak w tym przypadku, nawet bez hasła, użytkownik będzie mógł uzyskać dostęp do dokumentu i otworzyć go. W trybie tylko do odczytu użytkownik może przeglądać zawartość – hiperłącza, animacje, efekty i inne elementy – ale nie może kopiować elementów ani zapisywać prezentacji.

- **Otwieranie**

  Jeśli chcesz, aby tylko wybrani użytkownicy mogli otworzyć Twoją prezentację, możesz ustawić ograniczenie otwierania. Ograniczenie to uniemożliwia osobom nawet przeglądanie zawartości Twojej prezentacji (chyba że podadzą hasło).

  Technicznie ograniczenie otwierania zapobiega także modyfikacji prezentacji: kiedy ludzie nie mogą otworzyć prezentacji, nie mogą jej modyfikować ani wprowadzać zmian.

  **Uwaga**: gdy zabezpieczasz prezentację hasłem w celu uniemożliwienia otwarcia, plik prezentacji zostaje zaszyfrowany.

## **Jak zabezpieczyć prezentację hasłem online**

1. Przejdź do naszej strony [**Aspose.Slides Lock**](https://products.aspose.app/slides/pl/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Kliknij **Drop or upload your files**.

3. Wybierz plik, który chcesz zabezpieczyć hasłem, na swoim komputerze.

4. Wprowadź preferowane hasło dla ochrony edycji; wprowadź preferowane hasło dla ochrony podglądu.

5. Jeśli chcesz, aby użytkownicy widzieli Twoją prezentację jako ostateczną kopię, zaznacz pole wyboru **Mark as final**.

6. Kliknij **PROTECT NOW.**

7. Kliknij **DOWNLOAD NOW.**

## **Ochrona hasłem prezentacji w Aspose.Slides**
**Obsługiwane formaty**

Aspose.Slides obsługuje ochronę hasłem, szyfrowanie i podobne operacje dla prezentacji w następujących formatach:

- PPTX i PPT – Microsoft PowerPoint Presentation  
- ODP – OpenDocument Presentation  
- OTP – OpenDocument Presentation Template  

**Obsługiwane operacje**

Aspose.Slides umożliwia stosowanie ochrony hasłem w prezentacjach w następujący sposób:

- Szyfrowanie prezentacji  
- Ustawianie ochrony przed zapisem (write protection) dla prezentacji  

**Inne operacje**

Aspose.Slides pozwala wykonywać dodatkowe czynności związane z ochroną hasłem i szyfrowaniem w następujący sposób:

- Odszyfrowywanie prezentacji; otwieranie zaszyfrowanej prezentacji  
- Usuwanie szyfrowania; wyłączanie ochrony hasłem  
- Usuwanie ochrony przed zapisem z prezentacji  
- Pobieranie właściwości zaszyfrowanej prezentacji  
- Sprawdzanie, czy prezentacja jest zaszyfrowana  
- Sprawdzanie, czy prezentacja jest chroniona hasłem.

## **Szyfrowanie prezentacji**

Możesz zaszyfrować prezentację, ustawiając hasło. Następnie, aby zmodyfikować zablokowaną prezentację, użytkownik musi podać hasło.

Aby zaszyfrować lub zabezpieczyć prezentację hasłem, należy użyć metody **encrypt** (z klasy [ProtectionManager](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.protection_manager)) i podać hasło. Następnie metodą **save** zapisujesz zaszyfrowaną prezentację.

Poniższy przykładowy kod pokazuje, jak zaszyfrować prezentację:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Ustawianie ochrony przed zapisem (Write Protection) dla prezentacji**

Możesz dodać znacznik „Do not modify” do prezentacji. Dzięki temu informujesz użytkowników, że nie chcesz, aby wprowadzali zmiany w prezentacji.

**Uwaga**: proces ochrony przed zapisem nie szyfruje prezentacji. Dlatego użytkownicy – jeśli naprawdę chcą – mogą modyfikować prezentację, ale aby zapisać zmiany, będą musieli utworzyć prezentację pod inną nazwą.

Aby ustawić ochronę przed zapisem, użyj metody **setWriteProtection**. Poniższy kod demonstruje, jak to zrobić:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Ładowanie zaszyfrowanej prezentacji**

Aspose.Slides umożliwia ładowanie zaszyfrowanego pliku po podaniu jego hasła. Aby odszyfrować prezentację, należy wywołać metodę [RemoveEncryption](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) bez parametrów, a następnie wprowadzić prawidłowe hasło.

Poniższy przykładowy kod pokazuje, jak odszyfrować prezentację:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// pracuj z odszyfrowaną prezentacją
```

## **Usuwanie szyfrowania z prezentacji**

Możesz usunąć szyfrowanie lub ochronę hasłem z prezentacji, co pozwala użytkownikom na dostęp i modyfikację bez ograniczeń.

Aby usunąć szyfrowanie lub ochronę hasłem, wywołaj metodę [RemoveEncryption](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Poniższy kod ilustruje usuwanie szyfrowania:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Usuwanie ochrony przed zapisem z prezentacji**

Możesz użyć Aspose.Slides do usunięcia ochrony przed zapisem zastosowanej do pliku prezentacji. Dzięki temu użytkownicy mogą modyfikować dokument bez ostrzeżeń.

Aby usunąć ochronę przed zapisem, użyj metody [RemoveWriteProtection](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Przykładowy kod prezentuje, jak to zrobić:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Pobieranie właściwości zaszyfrowanej prezentacji**

Zwykle użytkownicy mają problem z uzyskaniem właściwości dokumentu zaszyfrowanej lub chronionej hasłem prezentacji. Aspose.Slides oferuje mechanizm, który pozwala chronić prezentację hasłem, jednocześnie umożliwiając dostęp do jej właściwości.

**Uwaga**: gdy Aspose.Slides szyfruje prezentację, właściwości dokumentu tej prezentacji są domyślnie również chronione hasłem. Jeśli jednak chcesz udostępnić właściwości po zaszyfrowaniu, Aspose.Slides umożliwia to.

Aby umożliwić dostęp do właściwości po szyfrowaniu, przekaż `true` do metody [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d). Poniższy kod pokazuje, jak zaszyfrować prezentację i jednocześnie udostępnić jej właściwości:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **Sprawdzanie, czy prezentacja jest chroniona hasłem**

Zanim załadujesz prezentację, możesz sprawdzić, czy nie jest ona chroniona hasłem. Dzięki temu unikniesz błędów i problemów, które pojawiają się przy ładowaniu prezentacji zabezpieczonej bez podania hasła.

Ten kod w C++ pokazuje, jak zbadać prezentację pod kątem ochrony hasłem (bez jej ładowania):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Sprawdzanie, czy prezentacja jest zaszyfrowana**

Aspose.Slides pozwala sprawdzić, czy prezentacja jest zaszyfrowana. W tym celu użyj metody [get_IsEncrypted()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), która zwraca `true`, jeśli prezentacja jest zaszyfrowana, lub `false`, jeśli nie jest zaszyfrowana.

Poniższy kod demonstruje, jak sprawdzić, czy prezentacja jest zaszyfrowana:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Sprawdzanie, czy prezentacja jest chroniona przed zapisem**

Aspose.Slides umożliwia sprawdzenie, czy prezentacja jest chroniona przed zapisem. W tym celu użyj metody [get_IsWriteProtected()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), która zwraca `true`, jeśli prezentacja jest chroniona przed zapisem, lub `false`, jeśli nie jest chroniona.

Poniższy kod pokazuje, jak sprawdzić ochronę przed zapisem:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Weryfikacja użycia hasła w prezentacji**

Możesz zweryfikować, czy określone hasło zostało użyte do ochrony dokumentu prezentacji. Aspose.Slides udostępnia mechanizm pozwalający zweryfikować hasło.

Poniższy przykład pokazuje, jak zweryfikować hasło:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// sprawdź, czy "pass" jest dopasowane do
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Zwraca `true`, jeśli prezentacja została zaszyfrowana podanym hasłem. W przeciwnym razie zwraca `false`.

{{% alert color="primary" title="Zobacz także" %}} 
- [Digital Signature in PowerPoint](/slides/pl/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jakie metody szyfrowania są obsługiwane przez Aspose.Slides?**

Aspose.Slides obsługuje nowoczesne metody szyfrowania, w tym algorytmy oparte na AES, zapewniając wysoki poziom bezpieczeństwa danych w Twoich prezentacjach.

**Co się dzieje, gdy podane zostanie nieprawidłowe hasło przy próbie otwarcia prezentacji?**

Zostaje wyrzucony wyjątek informujący, że dostęp do prezentacji został odrzucony. Pomaga to zapobiegać nieautoryzowanemu dostępowi i chronić zawartość prezentacji.

**Czy istnieją konsekwencje wydajnościowe przy pracy z prezentacjami chronionymi hasłem?**

Proces szyfrowania i odszyfrowywania może wprowadzić niewielkie obciążenie podczas operacji otwierania i zapisywania. W większości przypadków wpływ na wydajność jest minimalny i nie wpływa znacząco na całkowity czas przetwarzania zadań związanych z prezentacjami.