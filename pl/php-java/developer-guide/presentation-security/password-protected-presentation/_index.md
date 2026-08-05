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
description: "Dowiedz się, jak łatwo blokować i odblokowywać prezentacje PowerPoint i OpenDocument zabezpieczone hasłem przy użyciu Aspose.Slides dla PHP. Zabezpiecz swoje prezentacje."
---
## **Wprowadzenie**

Kiedy zabezpieczasz prezentację hasłem, oznacza to, że ustawiasz hasło, które narzuca określone ograniczenia na prezentację. Aby usunąć te ograniczenia, należy wprowadzić hasło. Prezentacja zabezpieczona hasłem jest uważana za zablokowaną prezentację.

Zazwyczaj możesz ustawić hasło, aby wymusić te ograniczenia na prezentacji:

- **Modyfikacja**

  Jeśli chcesz, aby tylko określeni użytkownicy mogli modyfikować twoją prezentację, możesz ustawić ograniczenie modyfikacji. To ograniczenie zapobiega osobom modyfikowanie, zmienianie lub kopiowanie elementów w twojej prezentacji (chyba że podadzą hasło). 

  Jednak w tym przypadku, nawet bez hasła, użytkownik będzie mógł uzyskać dostęp do dokumentu i go otworzyć. W trybie tylko do odczytu użytkownik może przeglądać zawartość lub elementy — hiperłącza, animacje, efekty i inne — w prezentacji, ale nie może kopiować elementów ani zapisywać prezentacji. 

- **Otwieranie**

  Jeśli chcesz, aby tylko określeni użytkownicy mogli otworzyć twoją prezentację, możesz ustawić ograniczenie otwierania. To ograniczenie zapobiega osobom nawet przeglądanie zawartości twojej prezentacji (chyba że podadzą hasło).

  Technicznie ograniczenie otwierania również zapobiega użytkownikom modyfikowanie twoich prezentacji: gdy osoby nie mogą otworzyć prezentacji, nie mogą jej modyfikować ani wprowadzać zmian do niej. 

**Uwaga** że gdy zabezpieczasz prezentację hasłem, aby uniemożliwić otwarcie, plik prezentacji zostaje zaszyfrowany.

## **Jak zabezpieczyć prezentację hasłem online**

1. Przejdź do naszej strony [**Aspose.Slides Lock**](https://products.aspose.app/slides/pl/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Kliknij **Drop or upload your files**.

3. Wybierz plik, który chcesz zabezpieczyć hasłem, na swoim komputerze.

4. Wpisz wybrane hasło do ochrony edycji; Wpisz wybrane hasło do ochrony podglądu.

5. Jeśli chcesz, aby użytkownicy zobaczyli twoją prezentację jako ostateczną kopię, zaznacz pole wyboru **Mark as final**.

6. Kliknij **PROTECT NOW.**

7. Kliknij **DOWNLOAD NOW.**

## **Ochrona hasłem prezentacji w Aspose.Slides**
**Obsługiwane formaty**

Aspose.Slides obsługuje ochronę hasłem, szyfrowanie i podobne operacje dla prezentacji w następujących formatach: 

- PPTX i PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP - OpenDocument Presentation Template 

**Obsługiwane operacje**

Aspose.Slides umożliwia użycie ochrony hasłem na prezentacjach w celu zapobiegania modyfikacjom w następujący sposób:

- Szyfrowanie prezentacji
- Ustawienie ochrony przed zapisem dla prezentacji

**Inne operacje**

Aspose.Slides umożliwia wykonywanie innych zadań związanych z ochroną hasłem i szyfrowaniem w następujący sposób:

- Odszyfrowywanie prezentacji; otwieranie zaszyfrowanej prezentacji
- Usuwanie szyfrowania; wyłączanie ochrony hasłem
- Usuwanie ochrony przed zapisem z prezentacji
- Pobieranie właściwości zaszyfrowanej prezentacji
- Sprawdzanie, czy prezentacja jest zaszyfrowana
- Sprawdzanie, czy prezentacja jest zabezpieczona hasłem.

## **Zaszyfruj prezentację**

Możesz zaszyfrować prezentację, ustawiając hasło. Następnie, aby zmodyfikować zablokowaną prezentację, użytkownik musi podać hasło. 

Aby zaszyfrować lub zabezpieczyć prezentację hasłem, należy użyć metody encrypt (z [ProtectionManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/)) aby ustawić hasło dla prezentacji. Przekazujesz hasło do metody encrypt i używasz metody save, aby zapisać teraz zaszyfrowaną prezentację.

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

Możesz dodać znacznik z napisem “Do not modify” do prezentacji. W ten sposób informujesz użytkowników, że nie chcesz, aby wprowadzali zmiany w prezentacji.  

**Uwaga** że proces ochrony przed zapisem nie szyfruje prezentacji. Dlatego użytkownicy — jeśli naprawdę chcą — mogą modyfikować prezentację, ale aby zapisać zmiany, będą musieli utworzyć prezentację pod inną nazwą. 

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

## **Wczytaj zaszyfrowaną prezentację**

Aspose.Slides umożliwia wczytanie zaszyfrowanego pliku, podając jego hasło. Aby odszyfrować prezentację, musisz wywołać metodę [removeEncryption](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#removeEncryption) bez parametrów. Następnie będziesz musiał wprowadzić prawidłowe hasło, aby wczytać prezentację.

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

## **Usuń szyfrowanie z prezentacji**

Możesz usunąć szyfrowanie lub ochronę hasłem w prezentacji. W ten sposób użytkownicy będą mogli uzyskać dostęp lub modyfikować prezentację bez ograniczeń. 

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

## **Usuń ochronę przed zapisem z prezentacji**

Możesz użyć Aspose.Slides, aby usunąć ochronę przed zapisem zastosowaną w pliku prezentacji. W ten sposób użytkownicy mogą modyfikować według własnego uznania — i nie otrzymują ostrzeżeń podczas wykonywania takich działań.

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

## **Pobierz właściwości zaszyfrowanej prezentacji**

Zazwyczaj użytkownicy mają trudności z pobraniem właściwości dokumentu zaszyfrowanej lub chronionej hasłem prezentacji. Jednak Aspose.Slides oferuje mechanizm, który pozwala zabezpieczyć prezentację hasłem, zachowując jednocześnie możliwość dostępu użytkowników do jej właściwości.

**Uwaga:** Domyślnie, gdy Aspose.Slides szyfruje prezentację, właściwości dokumentu prezentacji również są chronione hasłem. Jeśli potrzebujesz udostępnić właściwości dokumentu nawet po szyfrowaniu, Aspose.Slides umożliwia dokładnie to.

Jeśli chcesz, aby użytkownicy zachowali możliwość dostępu do właściwości zaszyfrowanej prezentacji, przekaż `false` do [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties). Ten przykładowy kod pokazuje, jak zaszyfrować prezentację, jednocześnie udostępniając użytkownikom dostęp do jej właściwości dokumentu:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Wczytaj tylko właściwości dokumentu z zaszyfrowanej prezentacji**

Aby przejrzeć metadane zaszyfrowanej prezentacji bez wczytywania jej slajdów lub innej zawartości, utwórz obiekt [LoadOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/) i przekaż `true` do [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties). W tym trybie Aspose.Slides ignoruje hasło i wczytuje tylko właściwości dokumentu, które są publicznie dostępne.

Poniższy przykład kodu odczytuje wbudowane i niestandardowe właściwości dokumentu przy użyciu [Presentation::getDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();

    # Odczytaj wbudowane właściwości dokumentu.
    echo("Title: " . $documentProperties->getTitle() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");

    # Odczytaj niestandardowe właściwości dokumentu.
    $customPropertyCount = java_values($documentProperties->getCountOfCustomProperties());

    for ($propertyIndex = 0; $propertyIndex < $customPropertyCount; $propertyIndex++) {
        $propertyName = $documentProperties->getCustomPropertyName($propertyIndex);
        $propertyValue = java_values($documentProperties->get_Item($propertyName));

        echo($propertyName . ": " . $propertyValue . "\n");
    }
} finally {
    $presentation->dispose();
}
```

Ten przepływ pracy działa tylko wtedy, gdy właściwości dokumentu zostały pozostawione niezaszyfrowane (publiczne) podczas szyfrowania prezentacji. Jeśli właściwości dokumentu są zaszyfrowane, przekazanie `true` do [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) powoduje wyjątek, ponieważ w tym trybie hasło jest ignorowane. Aby uzyskać dostęp do zaszyfrowanych właściwości dokumentu lub wczytać pełną prezentację, w tym jej slajdy i inną zawartość, podaj właściwe hasło przy użyciu [LoadOptions::setPassword](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setPassword).

## **Sprawdź, czy prezentacja jest chroniona hasłem**

Zanim wczytasz prezentację, możesz chcieć sprawdzić i potwierdzić, że prezentacja nie została zabezpieczona hasłem. Dzięki temu unikniesz błędów i podobnych problemów, które pojawiają się, gdy prezentacja chroniona hasłem jest wczytywana bez hasła.

Ten kod PHP pokazuje, jak zbadać prezentację, aby sprawdzić, czy jest chroniona hasłem (bez wczytywania samej prezentacji):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Sprawdź, czy prezentacja jest zaszyfrowana**

Aspose.Slides umożliwia sprawdzenie, czy prezentacja jest zaszyfrowana. Aby wykonać to zadanie, możesz użyć metody [isEncrypted](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#isEncrypted), która zwraca `true`, jeśli prezentacja jest zaszyfrowana, lub `false`, jeśli nie jest zaszyfrowana.

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

## **Sprawdź, czy prezentacja jest chroniona przed zapisem**

Aspose.Slides umożliwia sprawdzenie, czy prezentacja jest chroniona przed zapisem. Aby wykonać to zadanie, możesz użyć metody [isWriteProtected](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#isWriteProtected), która zwraca `true`, jeśli prezentacja jest chroniona przed zapisem, lub `false`, jeśli nie jest chroniona przed zapisem.

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

## **Sprawdź lub potwierdź, że użyto określonego hasła**

Możesz chcieć sprawdzić i potwierdzić, że określone hasło zostało użyte do zabezpieczenia dokumentu prezentacji. Aspose.Slides zapewnia możliwości walidacji hasła. 

Ten przykładowy kod pokazuje, jak zweryfikować hasło:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # sprawdź, czy "pass" jest dopasowane
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Zwraca `true`, jeśli prezentacja została zaszyfrowana przy użyciu określonego hasła. W przeciwnym razie zwraca `false`.

{{% alert color="primary" title="Zobacz także" %}} 
- [Digital Signature in PowerPoint](/slides/pl/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jakie metody szyfrowania są obsługiwane przez Aspose.Slides?**

Aspose.Slides obsługuje nowoczesne metody szyfrowania, w tym algorytmy oparte na AES, zapewniając wysokie bezpieczeństwo danych Twoich prezentacji.

**Co się stanie, jeśli wprowadzono nieprawidłowe hasło przy próbie otwarcia prezentacji?**

Zostaje wyrzucony wyjątek, jeśli użyto nieprawidłowego hasła, informując, że dostęp do prezentacji został odrzucony. Pomaga to zapobiec nieautoryzowanemu dostępowi i chroni zawartość prezentacji.

**Czy istnieją jakiekolwiek konsekwencje wydajnościowe przy pracy z prezentacjami chronionymi hasłem?**

Proces szyfrowania i odszyfrowywania może wprowadzić niewielkie obciążenie podczas operacji otwierania i zapisywania. W większości przypadków wpływ ten na wydajność jest minimalny i nie wpływa znacząco na ogólny czas przetwarzania zadań związanych z prezentacją.