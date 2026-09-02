---
title: Zabezpiecz prezentacje hasłem na Androidzie
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/androidjava/password-protected-presentation/
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
  - Android
  - Java
  - Aspose.Slides
description: "Łatwo blokuj i odblokowuj prezentacje PowerPoint i OpenDocument chronione hasłem przy użyciu Aspose.Slides dla Androida w języku Java. Zabezpiecz swoje prezentacje."
---
## **Wprowadzenie**

Gdy zabezpieczasz prezentację hasłem, oznacza to, że ustawiasz hasło wymuszające określone ograniczenia na prezentacji. Aby usunąć ograniczenia, należy wprowadzić hasło. Prezentacja chroniona hasłem jest uznawana za zablokowaną prezentację.

Zazwyczaj możesz ustawić hasło, aby wymusić te ograniczenia na prezentacji:

- **Modyfikacja**

  Jeśli chcesz, aby tylko określeni użytkownicy mogli modyfikować Twoją prezentację, możesz ustawić ograniczenie modyfikacji. To ograniczenie zapobiega osobom modyfikowanie, zmienianie lub kopiowanie elementów w Twojej prezentacji (chyba że podadzą hasło). 

  Jednak w tym przypadku, nawet bez hasła, użytkownik będzie mógł uzyskać dostęp do dokumentu i otworzyć go. W trybie tylko do odczytu użytkownik może przeglądać zawartość lub elementy — hiperlinki, animacje, efekty i inne — w prezentacji, ale nie może kopiować elementów ani zapisywać prezentacji. 

- **Otwieranie**

  Jeśli chcesz, aby tylko określeni użytkownicy mogli otworzyć Twoją prezentację, możesz ustawić ograniczenie otwierania. To ograniczenie zapobiega osobom nawet przeglądanie zawartości Twojej prezentacji (chyba że podadzą hasło).

  Technicznie, ograniczenie otwierania również uniemożliwia użytkownikom modyfikowanie prezentacji: gdy osoby nie mogą otworzyć prezentacji, nie mogą jej modyfikować ani wprowadzać zmian. 
  
  **Uwaga** że gdy zabezpieczasz prezentację hasłem, aby uniemożliwić jej otwarcie, plik prezentacji zostaje zaszyfrowany.

## **Zabezpieczanie hasłem prezentacji w Aspose.Slides**
**Obsługiwane formaty**

Aspose.Slides obsługuje zabezpieczanie hasłem, szyfrowanie i podobne operacje dla prezentacji w następujących formatach: 

- PPTX i PPT – prezentacja Microsoft PowerPoint 
- ODP – prezentacja OpenDocument 
- OTP – szablon prezentacji OpenDocument 

**Obsługiwane operacje**

Aspose.Slides pozwala używać zabezpieczenia hasłem na prezentacjach, aby zapobiec modyfikacjom w następujący sposób:

- Szyfrowanie prezentacji
- Ustawianie ochrony przed zapisem na prezentacji

**Inne operacje**

Aspose.Slides umożliwia wykonywanie innych zadań związanych z zabezpieczaniem hasłem i szyfrowaniem w następujący sposób:

- Odszyfrowywanie prezentacji; otwieranie zaszyfrowanej prezentacji
- Usuwanie szyfrowania; wyłączanie zabezpieczenia hasłem
- Usuwanie ochrony przed zapisem z prezentacji
- Pobieranie właściwości zaszyfrowanej prezentacji
- Sprawdzanie, czy prezentacja jest zaszyfrowana
- Sprawdzanie, czy prezentacja jest chroniona hasłem.

## **Szyfrowanie prezentacji**

Możesz zaszyfrować prezentację, ustawiając hasło. Następnie, aby zmodyfikować zablokowaną prezentację, użytkownik musi podać hasło. 

Aby zaszyfrować lub zabezpieczyć prezentację hasłem, musisz użyć metody encrypt (z [IProtectionManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IProtectionManager)) i ustawić hasło dla prezentacji. Przekazujesz hasło do metody encrypt i używasz metody save, aby zapisać teraz zaszyfrowaną prezentację.

Ten przykładowy kod pokazuje, jak zaszyfrować prezentację:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ustawianie ochrony przed zapisem na prezentacji**

Możesz dodać znacznik „Nie modyfikować” do prezentacji. W ten sposób informujesz użytkowników, że nie chcesz, aby wprowadzali zmiany w prezentacji.  

**Uwaga** że proces ochrony przed zapisem nie szyfruje prezentacji. Dlatego użytkownicy — jeśli naprawdę chcą — mogą modyfikować prezentację, ale aby zapisać zmiany, będą musieli utworzyć prezentację pod inną nazwą. 

Aby ustawić ochronę przed zapisem, musisz użyć metody [setWriteProtection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Ten przykładowy kod pokazuje, jak ustawić ochronę przed zapisem na prezentacji:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ładowanie zaszyfrowanej prezentacji**

Aspose.Slides pozwala ładować zaszyfrowany plik, podając jego hasło. Aby odszyfrować prezentację, musisz wywołać metodę [removeEncryption](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) bez parametrów. Następnie będziesz musiał wprowadzić prawidłowe hasło, aby załadować prezentację.

Ten przykładowy kod pokazuje, jak odszyfrować prezentację: 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // pracuj z odszyfrowaną prezentacją
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Usuwanie szyfrowania z prezentacji**

Możesz usunąć szyfrowanie lub zabezpieczenie hasłem na prezentacji. W ten sposób użytkownicy będą mogli uzyskać dostęp lub modyfikować prezentację bez ograniczeń. 

Aby usunąć szyfrowanie lub zabezpieczenie hasłem, musisz wywołać metodę [removeEncryption](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--). Ten przykładowy kod pokazuje, jak usunąć szyfrowanie z prezentacji:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Usuwanie ochrony przed zapisem z prezentacji**

Możesz użyć Aspose.Slides, aby usunąć ochronę przed zapisem używaną w pliku prezentacji. W ten sposób użytkownicy mogą modyfikować ją dowolnie — i nie otrzymują ostrzeżeń przy wykonywaniu takich zadań.

Możesz usunąć ochronę przed zapisem z prezentacji, używając metody [removeWriteProtection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Ten przykładowy kod pokazuje, jak usunąć ochronę przed zapisem z prezentacji:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Pobieranie właściwości zaszyfrowanej prezentacji**

Zwykle użytkownicy mają trudności z odczytaniem właściwości dokumentu zaszyfrowanej lub chronionej hasłem prezentacji. Jednak Aspose.Slides oferuje mechanizm, który pozwala zabezpieczyć prezentację hasłem, jednocześnie umożliwiając użytkownikom dostęp do jej właściwości.

**Uwaga:** Domyślnie, gdy Aspose.Slides szyfruje prezentację, właściwości dokumentu tej prezentacji również są chronione hasłem. Jeśli potrzebujesz, aby właściwości dokumentu były dostępne nawet po szyfrowaniu, Aspose.Slides umożliwia właśnie to.

Jeśli chcesz, aby użytkownicy zachowali możliwość dostępu do właściwości zaszyfrowanej prezentacji, przekaż `false` do [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Ten przykładowy kod pokazuje, jak szyfrować prezentację, jednocześnie udostępniając użytkownikom dostęp do jej właściwości dokumentu:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ładowanie wyłącznie właściwości dokumentu z zaszyfrowanej prezentacji**

Aby sprawdzić metadane zaszyfrowanej prezentacji bez ładowania jej slajdów lub innej zawartości, utwórz obiekt [LoadOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/) i przekaż `true` do [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). W tym trybie Aspose.Slides ignoruje hasło i ładuje tylko właściwości dokumentu, które są publicznie dostępne.

Poniższy przykład kodu odczytuje wbudowane i niestandardowe właściwości dokumentu za pomocą [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Odczytaj wbudowane właściwości dokumentu.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Odczytaj niestandardowe właściwości dokumentu.
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Ten przepływ działa tylko wtedy, gdy właściwości dokumentu zostały pozostawione niezaszyfrowane (publiczne) w momencie szyfrowania prezentacji. Jeśli właściwości dokumentu są zaszyfrowane, przekazanie `true` do `loadOptions.setOnlyLoadDocumentProperties` spowoduje wyjątek, ponieważ hasło jest ignorowane w tym trybie. Aby uzyskać dostęp do zaszyfrowanych właściwości dokumentu lub załadować pełną prezentację, w tym slajdy i inną zawartość, podaj prawidłowe hasło za pomocą [ILoadOptions.setPassword](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Sprawdzanie, czy prezentacja jest chroniona hasłem**

Zanim załadujesz prezentację, możesz chcieć sprawdzić i potwierdzić, że prezentacja nie jest chroniona hasłem. W ten sposób unikasz błędów i podobnych problemów, które pojawiają się, gdy prezentacja chroniona hasłem jest ładowana bez podania hasła.

Ten kod Java pokazuje, jak zbadać prezentację, aby sprawdzić, czy jest chroniona hasłem (bez ładowania samej prezentacji):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Sprawdzanie, czy prezentacja jest zaszyfrowana**

Aspose.Slides pozwala sprawdzić, czy prezentacja jest zaszyfrowana. Aby wykonać to zadanie, możesz użyć właściwości [isEncrypted](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) zwracającej `true`, jeśli prezentacja jest zaszyfrowana, lub `false`, jeśli nie jest zaszyfrowana.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest zaszyfrowana:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Sprawdzanie, czy prezentacja jest chroniona przed zapisem**

Aspose.Slides pozwala sprawdzić, czy prezentacja jest chroniona przed zapisem. Aby wykonać to zadanie, możesz użyć właściwości [isWriteProtected](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) zwracającej `true`, jeśli prezentacja jest zaszyfrowana, lub `false`, jeśli nie jest zaszyfrowana.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest chroniona przed zapisem:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Walidacja lub potwierdzenie użycia konkretnego hasła**

Możesz chcieć sprawdzić i potwierdzić, że określone hasło zostało użyte do zabezpieczenia dokumentu prezentacji. Aspose.Slides zapewnia środki do walidacji hasła. 

Ten przykładowy kod pokazuje, jak zwalidować hasło:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // sprawdź, czy "pass" pasuje
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Zwraca `true`, jeśli prezentacja została zaszyfrowana przy użyciu podanego hasła. W przeciwnym razie zwraca `false`. 

{{% alert color="primary" title="Zobacz także" %}} 
- [Podpis cyfrowy w PowerPoint](/slides/pl/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jakie metody szyfrowania są obsługiwane przez Aspose.Slides?**

Aspose.Slides obsługuje nowoczesne metody szyfrowania, w tym algorytmy oparte na AES, zapewniając wysoką ochronę danych w Twoich prezentacjach.

**Co się stanie, jeśli wprowadzono nieprawidłowe hasło przy próbie otwarcia prezentacji?**

Zostaje zgłoszony wyjątek, jeśli użyto nieprawidłowego hasła, informujący, że dostęp do prezentacji został odrzucony. Pomaga to zapobiec nieautoryzowanemu dostępowi i chroni zawartość prezentacji.

**Czy istnieją jakieś konsekwencje wydajnościowe przy pracy z prezentacjami zabezpieczonymi hasłem?**

Proces szyfrowania i odszyfrowywania może wprowadzić niewielkie obciążenie podczas operacji otwierania i zapisywania. W większości przypadków wpływ na wydajność jest minimalny i nie wpływa znacząco na całkowity czas przetwarzania zadań związanych z prezentacją.