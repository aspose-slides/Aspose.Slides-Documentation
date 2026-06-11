---
title: Zabezpiecz prezentacje hasłami w PHP
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/php-java/password-protected-presentation/
keywords:
- zablokuj PowerPoint
- zablokuj prezentację
- odblokuj PowerPoint
- odblokuj prezentację
- chroń PowerPoint
- chroń prezentację
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
- PHP
- Aspose.Slides
description: "Dowiedz się, jak łatwo blokować i odblokowywać hasłowo zabezpieczone prezentacje PowerPoint i OpenDocument przy użyciu Aspose.Slides dla PHP. Zabezpiecz swoje prezentacje."
---
## **Wprowadzenie**

Gdy zabezpieczasz prezentację hasłem, oznacza to, że ustawiasz hasło wymuszające określone ograniczenia na prezentacji. Aby usunąć ograniczenia, trzeba wprowadzić hasło. Prezentacja zabezpieczona hasłem jest uważana za zablokowaną prezentację.

Typowo możesz ustawić hasło, aby wymusić te ograniczenia na prezentacji:

- **Modyfikacja**

  Jeśli chcesz, aby tylko wybrani użytkownicy mogli modyfikować twoją prezentację, możesz ustawić ograniczenie modyfikacji. To ograniczenie uniemożliwia ludziom modyfikowanie, zmienianie lub kopiowanie elementów w twojej prezentacji (chyba że podadzą hasło). 

  Jednak w tym przypadku, nawet bez hasła, użytkownik będzie mógł uzyskać dostęp do dokumentu i go otworzyć. W trybie tylko do odczytu użytkownik może przeglądać zawartość, w tym linki, animacje, efekty i inne elementy prezentacji, ale nie może kopiować elementów ani zapisać prezentacji. 

- **Otwieranie**

  Jeśli chcesz, aby tylko wybrani użytkownicy mogli otworzyć twoją prezentację, możesz ustawić ograniczenie otwierania. To ograniczenie uniemożliwia ludziom nawet przeglądanie zawartości twojej prezentacji (chyba że podadzą hasło).

  Technicznie, ograniczenie otwierania również uniemożliwia użytkownikom modyfikację twoich prezentacji: gdy ludzie nie mogą otworzyć prezentacji, nie mogą jej modyfikować ani wprowadzać zmian. 
  
  **Uwaga** że gdy zabezpieczasz prezentację hasłem, aby uniemożliwić otwieranie, plik prezentacji zostaje zaszyfrowany.

## **Jak zabezpieczyć prezentację hasłem online**

1. Przejdź do naszej strony [**Aspose.Slides Lock**](https://products.aspose.app/slides/pl/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Kliknij **Drop or upload your files**.

3. Wybierz plik, który chcesz zabezpieczyć hasłem, na swoim komputerze. 

4. Wprowadź preferowane hasło do ochrony edycji; Wprowadź preferowane hasło do ochrony podglądu. 

5. Jeśli chcesz, aby użytkownicy widzieli twoją prezentację jako ostateczną kopię, zaznacz pole wyboru **Mark as final**.

6. Kliknij **PROTECT NOW.** 

7. Kliknij **DOWNLOAD NOW.**

## **Ochrona hasłem prezentacji w Aspose.Slides**
**Obsługiwane formaty**

Aspose.Slides obsługuje ochronę hasłem, szyfrowanie i podobne operacje dla prezentacji w następujących formatach: 

- PPTX i PPT – prezentacja Microsoft PowerPoint 
- ODP – prezentacja OpenDocument 
- OTP – szablon prezentacji OpenDocument 

**Obsługiwane operacje**

Aspose.Slides umożliwia użycie ochrony hasłem w prezentacjach, aby zapobiegać modyfikacjom w następujący sposób:

- Szyfrowanie prezentacji
- Ustawienie ochrony przed zapisem w prezentacji

**Inne operacje**

Aspose.Slides umożliwia wykonywanie innych zadań związanych z ochroną hasłem i szyfrowaniem w następujący sposób:

- Deszyfrowanie prezentacji; otwieranie zaszyfrowanej prezentacji
- Usuwanie szyfrowania; wyłączanie ochrony hasłem
- Usuwanie ochrony przed zapisem z prezentacji
- Pobieranie właściwości zaszyfrowanej prezentacji
- Sprawdzanie, czy prezentacja jest zaszyfrowana
- Sprawdzanie, czy prezentacja jest zabezpieczona hasłem.

## **Szyfrowanie prezentacji**

Możesz zaszyfrować prezentację, ustawiając hasło. Następnie, aby zmodyfikować zablokowaną prezentację, użytkownik musi podać hasło.

Aby zaszyfrować lub zabezpieczyć prezentację hasłem, musisz użyć metody encrypt (z [ProtectionManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/)) aby ustawić hasło dla prezentacji. Przekazujesz hasło do metody encrypt i używasz metody save, aby zapisać teraz zaszyfrowaną prezentację.

Ten przykładowy kod pokazuje, jak zaszyfrować prezentację:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Ustaw ochronę przed zapisem w prezentacji**

Możesz dodać znak „Do not modify” do prezentacji. W ten sposób informujesz użytkowników, że nie chcesz, aby wprowadzali zmiany w prezentacji.  

**Uwaga** że proces ochrony przed zapisem nie szyfruje prezentacji. Dlatego użytkownicy — jeśli naprawdę chcą — mogą modyfikować prezentację, ale aby zapisać zmiany, będą musieli stworzyć prezentację pod inną nazwą. 

Aby ustawić ochronę przed zapisem, musisz użyć metody [setWriteProtection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#setWriteProtection). Ten przykładowy kod pokazuje, jak ustawić ochronę przed zapisem w prezentacji:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setWriteProtection("123123");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Ładowanie zaszyfrowanej prezentacji**

Aspose.Slides umożliwia załadowanie zaszyfrowanego pliku, podając jego hasło. Aby odszyfrować prezentację, musisz wywołać metodę [removeEncryption](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#removeEncryption) bez parametrów. Następnie będziesz musiał wprowadzić prawidłowe hasło, aby załadować prezentację.

Ten przykładowy kod pokazuje, jak odszyfrować prezentację: 

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # pracuj z odszyfrowaną prezentacją
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Usuwanie szyfrowania z prezentacji**

Możesz usunąć szyfrowanie lub ochronę hasłem z prezentacji. W ten sposób użytkownicy będą mogli uzyskać dostęp lub modyfikować prezentację bez ograniczeń. 

Aby usunąć szyfrowanie lub ochronę hasłem, musisz wywołać metodę [removeEncryption](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#removeEncryption). Ten przykładowy kod pokazuje, jak usunąć szyfrowanie z prezentacji:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Usuwanie ochrony przed zapisem z prezentacji**

Możesz użyć Aspose.Slides do usunięcia ochrony przed zapisem użytej w pliku prezentacji. Dzięki temu użytkownicy mogą modyfikować ją dowolnie — i nie otrzymują ostrzeżeń przy wykonywaniu takich czynności.

Możesz usunąć ochronę przed zapisem z prezentacji, używając metody [removeWriteProtection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#removeWriteProtection). Ten przykładowy kod pokazuje, jak usunąć ochronę przed zapisem z prezentacji:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Pobieranie właściwości zaszyfrowanej prezentacji**

Zazwyczaj użytkownicy mają trudności z uzyskaniem właściwości dokumentu zaszyfrowanej lub zabezpieczonej hasłem prezentacji. Aspose.Slides oferuje jednak mechanizm, który pozwala zabezpieczyć prezentację hasłem, jednocześnie umożliwiając użytkownikom dostęp do jej właściwości.

**Uwaga** że gdy Aspose.Slides szyfruje prezentację, właściwości dokumentu prezentacji są domyślnie również chronione hasłem. Jednak jeśli potrzebujesz udostępnić właściwości prezentacji (nawet po jej zaszyfrowaniu), Aspose.Slides pozwala to zrobić. 

Jeśli chcesz, aby użytkownicy zachowali możliwość dostępu do właściwości prezentacji, którą zaszyfrowałeś, możesz użyć metody [encryptDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#getEncryptDocumentProperties) z wartością `true`. Ten przykładowy kod pokazuje, jak zaszyfrować prezentację, jednocześnie umożliwiając użytkownikom dostęp do jej właściwości dokumentu:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(true);
    $presentation->getProtectionManager()->encrypt("123123");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Sprawdzanie, czy prezentacja jest zabezpieczona hasłem**

Zanim załadujesz prezentację, możesz chcieć sprawdzić i potwierdzić, że nie została ona zabezpieczona hasłem. W ten sposób unikasz błędów i podobnych problemów, które występują, gdy prezentacja zabezpieczona hasłem zostaje załadowana bez podania hasła.

Ten kod PHP pokazuje, jak zbadać prezentację, aby sprawdzić, czy jest zabezpieczona hasłem (bez ładowania samej prezentacji):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Sprawdzanie, czy prezentacja jest zaszyfrowana**

Aspose.Slides pozwala sprawdzić, czy prezentacja jest zaszyfrowana. Do tego możesz użyć metody [isEncrypted](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#isEncrypted), która zwraca `true`, jeśli prezentacja jest zaszyfrowana, lub `false`, jeśli nie jest zaszyfrowana.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest zaszyfrowana:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Sprawdzanie, czy prezentacja jest chroniona przed zapisem**

Aspose.Slides pozwala sprawdzić, czy prezentacja jest chroniona przed zapisem. Do tego możesz użyć metody [isWriteProtected](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#isWriteProtected), która zwraca `true`, jeśli prezentacja jest zaszyfrowana, lub `false`, jeśli nie jest zaszyfrowana.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest chroniona przed zapisem:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Walidacja lub potwierdzenie, że użyto konkretnego hasła**

Możesz chcieć sprawdzić i potwierdzić, że określone hasło zostało użyte do zabezpieczenia dokumentu prezentacji. Aspose.Slides udostępnia środki do walidacji hasła. 

Ten przykładowy kod pokazuje, jak zweryfikować hasło:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # sprawdź, czy "pass" jest dopasowane do
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Zwraca `true`, jeśli prezentacja została zaszyfrowana podanym hasłem. W przeciwnym razie zwraca `false`. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/pl/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jakie metody szyfrowania są obsługiwane przez Aspose.Slides?**

Aspose.Slides obsługuje nowoczesne metody szyfrowania, w tym algorytmy oparte na AES, zapewniając wysoki poziom bezpieczeństwa danych Twoich prezentacji.

**Co się dzieje, jeśli wprowadzono nieprawidłowe hasło przy próbie otwarcia prezentacji?**

Jeśli użyto niepoprawnego hasła, zostaje wyrzucony wyjątek, informujący, że dostęp do prezentacji jest odrzucony. Pomaga to zapobiegać nieuprawnionemu dostępowi i chroni zawartość prezentacji.

**Czy istnieją jakiekolwiek konsekwencje wydajnościowe przy pracy z prezentacjami zabezpieczonymi hasłem?**

Proces szyfrowania i odszyfrowywania może wprowadzić niewielkie obciążenie podczas operacji otwierania i zapisywania. W większości przypadków wpływ na wydajność jest minimalny i nie wpływa znacząco na całkowity czas przetwarzania zadań związanych z prezentacją.