---
title: Zabezpiecz prezentacje hasłami w JavaScript
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/nodejs-java/password-protected-presentation/
keywords:
- zablokuj PowerPoint
- zablokuj prezentację
- odblokuj PowerPoint
- odblokuj prezentację
- ochroń PowerPoint
- ochroń prezentację
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Bezproblemowo blokuj i odblokowuj prezentacje PowerPoint i OpenDocument zabezpieczone hasłem przy pomocy Aspose.Slides dla Node.js w Java. Zabezpiecz swoje prezentacje."
---
## **Wprowadzenie**

Podczas gdy zabezpieczasz prezentację hasłem, ustawiasz hasło, które narzuca określone ograniczenia na prezentację. Aby usunąć ograniczenia, trzeba wprowadzić hasło. Prezentacja zabezpieczona hasłem jest uznawana za zablokowaną prezentację.

Zazwyczaj możesz ustawić hasło, aby wymusić te ograniczenia na prezentację:

- **Modyfikacja**

  Jeśli chcesz, aby tylko wybrani użytkownicy mogli modyfikować Twoją prezentację, możesz wprowadzić ograniczenie modyfikacji. Ograniczenie to zapobiega osobom modyfikowanie, zmienianie lub kopiowanie treści w prezentacji (chyba że podadzą hasło).

  Jednak w tym przypadku, nawet bez podania hasła, użytkownik będzie mógł uzyskać dostęp do dokumentu i otworzyć go. W trybie tylko do odczytu użytkownik może przeglądać zawartość – hiperlinki, animacje, efekty i inne elementy w prezentacji, ale nie może kopiować elementów ani zapisywać prezentacji.

- **Otwieranie**

  Jeśli chcesz, aby tylko określeni użytkownicy mogli otwierać Twoją prezentację, możesz wprowadzić ograniczenie otwierania. Ograniczenie to zapobiega osobom przeglądanie zawartości prezentacji (chyba że podadzą hasło).

  Technicznie ograniczenie otwierania również uniemożliwia użytkownikom modyfikację prezentacji: gdy nie mogą otworzyć prezentacji, nie mogą jej zmieniać ani wprowadzać zmian.

  **Uwaga** że gdy zabezpieczasz prezentację hasłem, aby uniemożliwić otwarcie, plik prezentacji zostaje zaszyfrowany.

## **Jak zabezpieczyć prezentację hasłem online**

1. Przejdź do naszej strony [**Aspose.Slides Lock**](https://products.aspose.app/slides/pl/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Kliknij **Drop or upload your files**.

3. Wybierz plik, który chcesz zabezpieczyć hasłem, na swoim komputerze.

4. Wprowadź preferowane hasło do ochrony edycji; Wprowadź preferowane hasło do ochrony podglądu.

5. Jeśli chcesz, aby użytkownicy widzieli prezentację jako ostateczną kopię, zaznacz pole wyboru **Mark as final**.

6. Kliknij **PROTECT NOW.**

7. Kliknij **DOWNLOAD NOW.**

## **Zabezpieczenia hasłem prezentacji w Aspose.Slides**
**Obsługiwane formaty**

Aspose.Slides obsługuje zabezpieczenia hasłem, szyfrowanie oraz podobne operacje dla prezentacji w następujących formatach:

- PPTX i PPT – prezentacja Microsoft PowerPoint
- ODP – OpenDocument Presentation
- OTP – szablon OpenDocument Presentation

**Obsługiwane operacje**

Aspose.Slides umożliwia stosowanie zabezpieczeń hasłem na prezentacjach, aby zapobiec modyfikacjom w następujący sposób:

- Szyfrowanie prezentacji
- Ustawienie ochrony przed zapisem na prezentacji

**Inne operacje**

Aspose.Slides pozwala na wykonywanie dodatkowych zadań związanych z zabezpieczeniami hasłem i szyfrowaniem w następujący sposób:

- Deszyfrowanie prezentacji; otwieranie zaszyfrowanej prezentacji
- Usuwanie szyfrowania; wyłączanie zabezpieczenia hasłem
- Usuwanie ochrony przed zapisem z prezentacji
- Pobieranie właściwości zaszyfrowanej prezentacji
- Sprawdzanie, czy prezentacja jest zaszyfrowana
- Sprawdzanie, czy prezentacja jest zabezpieczona hasłem.

## **Szyfrowanie prezentacji**

Możesz zaszyfrować prezentację, ustawiając hasło. Następnie, aby zmodyfikować zablokowaną prezentację, użytkownik musi podać hasło.

Aby zaszyfrować lub zabezpieczyć prezentację hasłem, należy użyć metody **encrypt** (z klasy [ProtectionManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ProtectionManager)) i podać hasło. Następnie użyj metody **save**, aby zapisać teraz zaszyfrowaną prezentację.

Ten przykładowy kod pokazuje, jak zaszyfrować prezentację:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Ustawianie ochrony przed zapisem w prezentacji**

Możesz dodać znacznik „Nie modyfikować” do prezentacji. Dzięki temu informujesz użytkowników, że nie chcesz, aby wprowadzali zmiany w prezentacji.

**Uwaga** że proces ochrony przed zapisem nie szyfruje prezentacji. W związku z tym użytkownicy – jeśli naprawdę będą chcieli – mogą modyfikować prezentację, ale aby zapisać zmiany, będą musieli utworzyć prezentację pod inną nazwą.

Aby ustawić ochronę przed zapisem, należy użyć metody [setWriteProtection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-). Ten przykładowy kod pokazuje, jak ustawić ochronę przed zapisem w prezentacji:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Deszyfrowanie prezentacji; otwieranie zaszyfrowanej prezentacji**

Aspose.Slides umożliwia wczytanie zaszyfrowanego pliku po podaniu jego hasła. Aby deszyfrować prezentację, należy wywołać metodę [removeEncryption](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) bez parametrów. Następnie trzeba wprowadzić poprawne hasło, aby wczytać prezentację.

Ten przykładowy kod pokazuje, jak deszyfrować prezentację:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // pracuj z odszyfrowaną prezentacją
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Usuwanie szyfrowania; wyłączanie zabezpieczenia hasłem**

Możesz usunąć szyfrowanie lub zabezpieczenie hasłem z prezentacji. W ten sposób użytkownicy mogą uzyskać dostęp lub modyfikować prezentację bez ograniczeń.

Aby usunąć szyfrowanie lub zabezpieczenie hasłem, należy wywołać metodę [removeEncryption](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) . Ten przykładowy kod pokazuje, jak usunąć szyfrowanie z prezentacji:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Usuwanie ochrony przed zapisem z prezentacji**

Możesz użyć Aspose.Slides do usunięcia ochrony przed zapisem zastosowanej w pliku prezentacji. Dzięki temu użytkownicy mogą modyfikować ją dowolnie i nie otrzymują żadnych ostrzeżeń przy wykonywaniu takich działań.

Ochronę przed zapisem z prezentacji usuwa się za pomocą metody [removeWriteProtection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--) . Ten przykładowy kod pokazuje, jak usunąć ochronę przed zapisem z prezentacji:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Pobieranie właściwości zaszyfrowanej prezentacji**

Zwykle użytkownicy mają problem z odczytaniem właściwości dokumentu zaszyfrowanej lub zabezpieczonej hasłem prezentacji. Aspose.Slides oferuje mechanizm, który pozwala zabezpieczyć prezentację hasłem, a jednocześnie umożliwia użytkownikom dostęp do jej właściwości.

**Uwaga:** Domyślnie, gdy Aspose.Slides szyfruje prezentację, właściwości dokumentu prezentacji również zostają zabezpieczone hasłem. Jeśli potrzebujesz udostępnić właściwości dokumentu nawet po szyfrowaniu, Aspose.Slides umożliwia dokładnie to.

Jeśli chcesz, aby użytkownicy zachowali możliwość dostępu do właściwości zaszyfrowanej prezentacji, przekaż `false` do `setEncryptDocumentProperties` w klasie [ProtectionManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/protectionmanager/). Ten przykładowy kod pokazuje, jak szyfrować prezentację, jednocześnie udostępniając użytkownikom dostęp do jej właściwości dokumentu:

```javascript
const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Ładowanie wyłącznie właściwości dokumentu z zaszyfrowanej prezentacji**

Aby przejrzeć metadane zaszyfrowanej prezentacji bez wczytywania jej slajdów lub innej zawartości, utwórz obiekt [LoadOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/) i przekaż `true` do `setOnlyLoadDocumentProperties`. w tym trybie Aspose.Slides ignoruje hasło i ładuje jedynie właściwości dokumentu, które są publicznie dostępne.

Poniższy przykład kodu odczytuje wbudowane i niestandardowe właściwości dokumentu za pomocą `getDocumentProperties` w klasie [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/):

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new aspose.slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();

    // Odczytaj wbudowane właściwości dokumentu.
    console.log("Title: " + documentProperties.getTitle());
    console.log("Author: " + documentProperties.getAuthor());

    // Odczytaj niestandardowe właściwości dokumentu.
    const customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (let propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        const propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Ten przebieg działa tylko wtedy, gdy właściwości dokumentu pozostawiono niezaszyfrowane (publiczne) w momencie szyfrowania prezentacji. Jeśli właściwości dokumentu są zaszyfrowane, przekazanie `true` do `LoadOptions.setOnlyLoadDocumentProperties` spowoduje wyjątek, ponieważ w tym trybie hasło jest ignorowane. Aby uzyskać dostęp do zaszyfrowanych właściwości dokumentu lub wczytać pełną prezentację, włączając slajdy i inne treści, podaj poprawne hasło przez `LoadOptions.setPassword` w klasie [LoadOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/).

## **Sprawdzanie, czy prezentacja jest zabezpieczona hasłem przed jej załadowaniem**

Zanim wczytasz prezentację, możesz chcieć sprawdzić i potwierdzić, że nie została zabezpieczona hasłem. Dzięki temu unikniesz błędów i podobnych problemów, które pojawiają się przy wczytywaniu zabezpieczonej hasłem prezentacji bez podania hasła.

Ten kod JavaScript pokazuje, jak zbadać prezentację, aby sprawdzić, czy jest zabezpieczona hasłem (bez wczytywania samej prezentacji):

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Sprawdzanie, czy prezentacja jest zaszyfrowana**

Aspose.Slides umożliwia sprawdzenie, czy prezentacja jest zaszyfrowana. W tym celu możesz użyć właściwości [isEncrypted](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--), która zwraca `true`, jeśli prezentacja jest zaszyfrowana, lub `false`, jeśli nie jest.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest zaszyfrowana:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Sprawdzanie, czy prezentacja jest chroniona przed zapisem**

Aspose.Slides umożliwia sprawdzenie, czy prezentacja jest chroniona przed zapisem. W tym celu możesz użyć właściwości [isWriteProtected](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) , która zwraca `true`, jeśli prezentacja jest zaszyfrowana, lub `false`, jeśli nie jest.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest chroniona przed zapisem:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Walidacja lub potwierdzenie, że określone hasło zostało użyte do zabezpieczenia prezentacji**

Możesz chcieć sprawdzić i potwierdzić, że określone hasło zostało użyte do zabezpieczenia dokumentu prezentacji. Aspose.Slides udostępnia mechanizm pozwalający zweryfikować hasło.

Ten przykładowy kod pokazuje, jak zweryfikować hasło:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // sprawdź, czy "pass" pasuje do
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Zwraca `true`, jeśli prezentacja została zaszyfrowana przy użyciu podanego hasła. W przeciwnym razie zwraca `false`.

{{% alert color="primary" title="Zobacz również" %}} 
- [Digital Signature in PowerPoint](/slides/pl/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jakie metody szyfrowania są obsługiwane przez Aspose.Slides?**

Aspose.Slides obsługuje nowoczesne metody szyfrowania, w tym algorytmy oparte na AES, zapewniając wysoki poziom bezpieczeństwa danych w Twoich prezentacjach.

**Co się stanie, jeśli wprowadzono nieprawidłowe hasło przy próbie otwarcia prezentacji?**

Zostanie zgłoszony wyjątek, informujący, że dostęp do prezentacji został odrzucony. To pomaga zapobiegać nieuprawnionemu dostępowi i chroni zawartość prezentacji.

**Czy istnieją jakiekolwiek konsekwencje wydajnościowe przy pracy z prezentacjami zabezpieczonymi hasłem?**

Proces szyfrowania i deszyfrowania może wprowadzić niewielkie obciążenie podczas operacji otwierania i zapisywania. W większości przypadków wpływ na wydajność jest minimalny i nie wpływa znacząco na całkowity czas przetwarzania zadań związanych z prezentacją.