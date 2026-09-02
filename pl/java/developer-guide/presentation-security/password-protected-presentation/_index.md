---
title: Zabezpiecz prezentacje hasłami w Javie
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/java/password-protected-presentation/
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
- Java
- Aspose.Slides
description: "Dowiedz się, jak łatwo blokować i odblokowywać prezentacje PowerPoint oraz OpenDocument zabezpieczone hasłem przy użyciu Aspose.Slides dla Javy. Zabezpiecz swoje prezentacje."
---
## **Wprowadzenie**

Kiedy zabezpieczasz prezentację hasłem, oznacza to, że ustawiasz hasło, które wymusza określone ograniczenia na prezentacji. Aby usunąć te ograniczenia, należy wprowadzić hasło. Prezentacja zabezpieczona hasłem jest uważana za zablokowaną prezentację.

Typowo możesz ustawić hasło, aby wymusić te ograniczenia w prezentacji:

- **Modyfikacja**

Jeśli chcesz, aby tylko określeni użytkownicy mogli modyfikować Twoją prezentację, możesz ustawić ograniczenie modyfikacji. To ograniczenie uniemożliwia osobom modyfikowanie, zmienianie lub kopiowanie elementów w prezentacji, chyba że podadzą hasło.  

Jednak nawet bez hasła użytkownik nadal będzie mógł uzyskać dostęp i otworzyć Twój dokument. W tym trybie tylko do odczytu użytkownik może przeglądać zawartość — w tym hiperłącza, animacje, efekty i inne elementy — w Twojej prezentacji, ale nie może kopiować elementów ani zapisywać prezentacji.

- **Otwieranie**

Jeśli chcesz, aby tylko określeni użytkownicy mogli otworzyć Twoją prezentację, możesz ustawić ograniczenie otwierania. To ograniczenie uniemożliwia osobom nawet przeglądanie zawartości Twojej prezentacji, chyba że podadzą hasło.

Technicznie ograniczenie otwierania również uniemożliwia użytkownikom modyfikowanie prezentacji — jeśli ludzie nie mogą otworzyć prezentacji, nie mogą jej modyfikować ani wprowadzać zmian.

**Uwaga:** Kiedy zabezpieczasz prezentację hasłem, aby uniemożliwić jej otwarcie, plik prezentacji zostaje zaszyfrowany.

## **Ochrona hasłem w Aspose.Slides**
**Obsługiwane formaty**

Aspose.Slides obsługuje ochronę hasłem, szyfrowanie i podobne operacje dla prezentacji w następujących formatach: 

- PPTX and PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP -  OpenDocument Presentation Template 

**Obsługiwane operacje**

Aspose.Slides umożliwia użycie ochrony hasłem w prezentacjach, aby zapobiec modyfikacjom w następujący sposób:

- Szyfrowanie prezentacji
- Ustawienie ochrony przed zapisem w prezentacji

**Inne operacje**

Aspose.Slides pozwala na wykonywanie innych zadań związanych z ochroną hasłem i szyfrowaniem w następujący sposób:

- Odszyfrowywanie prezentacji; otwieranie zaszyfrowanej prezentacji
- Usuwanie szyfrowania; wyłączanie ochrony hasłem
- Usuwanie ochrony przed zapisem w prezentacji
- Pobieranie właściwości zaszyfrowanej prezentacji
- Sprawdzanie, czy prezentacja jest zaszyfrowana
- Sprawdzanie, czy prezentacja jest zabezpieczona hasłem.

## **Zabezpiecz prezentację hasłem**

Możesz zaszyfrować prezentację, ustawiając hasło. Następnie, aby zmodyfikować zablokowaną prezentację, użytkownik musi podać hasło. 

Aby zaszyfrować lub zabezpieczyć prezentację hasłem, musisz użyć metody encrypt (z [IProtectionManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IProtectionManager)), aby ustawić hasło dla prezentacji. Przekazujesz hasło do metody encrypt i używasz metody save, aby zapisać teraz zaszyfrowaną prezentację. 

Poniższy przykład kodu pokazuje, jak zaszyfrować prezentację:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ustaw ochronę przed zapisem w prezentacji**

Możesz dodać znak „Nie modyfikować” do prezentacji. W ten sposób informujesz użytkowników, że nie chcesz, aby wprowadzali zmiany w prezentacji.  

**Uwaga** że proces ochrony przed zapisem nie szyfruje prezentacji. Dlatego użytkownicy — jeśli naprawdę chcą — mogą modyfikować prezentację, ale aby zapisać zmiany, będą musieli utworzyć prezentację pod inną nazwą. 

Aby ustawić ochronę przed zapisem, musisz użyć metody [setWriteProtection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Poniższy przykład kodu pokazuje, jak ustawić ochronę przed zapisem w prezentacji:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Wczytaj zaszyfrowaną prezentację**

Aspose.Slides umożliwia wczytanie zaszyfrowanego pliku, podając jego hasło. Aby odszyfrować prezentację, musisz wywołać metodę [removeEncryption](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IProtectionManager#removeEncryption--) bez parametrów. Następnie będziesz musiał wprowadzić poprawne hasło, aby wczytać prezentację. 

Poniższy przykład kodu pokazuje, jak odszyfrować prezentację: 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // praca z odszyfrowaną prezentacją
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Usuń szyfrowanie z prezentacji**

Możesz usunąć szyfrowanie lub ochronę hasłem w prezentacji. W ten sposób użytkownicy mogą uzyskać dostęp do prezentacji lub modyfikować ją bez ograniczeń. 

Aby usunąć szyfrowanie lub ochronę hasłem, musisz wywołać metodę [removeEncryption](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IProtectionManager#removeEncryption--). Poniższy przykład kodu pokazuje, jak usunąć szyfrowanie z prezentacji:

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

## **Usuń ochronę przed zapisem z prezentacji**

Możesz użyć Aspose.Slides do usunięcia ochrony przed zapisem zastosowanej w pliku prezentacji. W ten sposób użytkownicy mogą modyfikować ją dowolnie — i nie otrzymają ostrzeżeń przy wykonywaniu takich czynności.

Możesz usunąć ochronę przed zapisem z prezentacji, używając metody [removeWriteProtection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IProtectionManager#removeWriteProtection--). Poniższy przykład kodu pokazuje, jak usunąć ochronę przed zapisem z prezentacji:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Pobierz właściwości zaszyfrowanej prezentacji**

Typowo użytkownicy mają problem z pobraniem właściwości dokumentu zaszyfrowanej lub zabezpieczonej hasłem prezentacji. Jednak Aspose.Slides oferuje mechanizm, który pozwala zabezpieczyć prezentację hasłem, jednocześnie zachowując możliwość dostępu użytkowników do jej właściwości.  

**Uwaga:** Domyślnie, gdy Aspose.Slides szyfruje prezentację, właściwości dokumentu prezentacji są również chronione hasłem. Jeśli potrzebujesz udostępnić właściwości dokumentu nawet po szyfrowaniu, Aspose.Slides umożliwia dokładnie to.  

Jeśli chcesz, aby użytkownicy zachowali możliwość dostępu do właściwości zaszyfrowanej prezentacji, przekaż `false` do [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Poniższy przykład kodu pokazuje, jak zaszyfrować prezentację, jednocześnie udostępniając użytkownikom dostęp do jej właściwości dokumentu:

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

## **Wczytaj tylko właściwości dokumentu z zaszyfrowanej prezentacji**

Aby sprawdzić metadane zaszyfrowanej prezentacji bez wczytywania jej slajdów ani innej zawartości, utwórz obiekt [LoadOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/) i przekaż `true` do [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). W tym trybie Aspose.Slides ignoruje hasło i wczytuje tylko właściwości dokumentu, które są publicznie dostępne.  

Poniższy przykład kodu odczytuje wbudowane i niestandardowe właściwości dokumentu za pomocą [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

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

Ten proces działa tylko wtedy, gdy właściwości dokumentu zostały pozostawione niezaszyfrowane (publiczne) podczas szyfrowania prezentacji. Jeśli właściwości dokumentu są zaszyfrowane, przekazanie `true` do `loadOptions.setOnlyLoadDocumentProperties` powoduje wyjątek, ponieważ hasło jest ignorowane w tym trybie. Aby uzyskać dostęp do zaszyfrowanych właściwości dokumentu lub wczytać pełną prezentację, wraz ze slajdami i inną zawartością, podaj prawidłowe hasło poprzez [ILoadOptions.setPassword](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Sprawdź, czy prezentacja jest zabezpieczona hasłem**

Zanim wczytasz prezentację, możesz chcieć sprawdzić i potwierdzić, że prezentacja nie jest zabezpieczona hasłem. W ten sposób unikniesz błędów i podobnych problemów, które pojawiają się, gdy zabezpieczona hasłem prezentacja jest wczytywana bez podania hasła.  

Poniższy kod Java pokazuje, jak zbadać prezentację, aby sprawdzić, czy jest zabezpieczona hasłem (bez wczytywania samej prezentacji):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Sprawdź, czy prezentacja jest zaszyfrowana**

Aspose.Slides umożliwia sprawdzenie, czy prezentacja jest zaszyfrowana. Aby wykonać to zadanie, możesz użyć właściwości [isEncrypted](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IProtectionManager#isEncrypted--), która zwraca `true`, jeśli prezentacja jest zaszyfrowana, lub `false`, jeśli nie jest zaszyfrowana.  

Poniższy przykład kodu pokazuje, jak sprawdzić, czy prezentacja jest zaszyfrowana:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Sprawdź, czy prezentacja jest zabezpieczona przed zapisem**

Aspose.Slides umożliwia sprawdzenie, czy prezentacja jest zabezpieczona przed zapisem. Aby wykonać to zadanie, możesz użyć właściwości [isWriteProtected](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IProtectionManager#isWriteProtected--), która zwraca `true`, jeśli prezentacja jest zabezpieczona przed zapisem, lub `false`, jeśli nie jest zabezpieczona przed zapisem.  

Poniższy przykład kodu pokazuje, jak sprawdzić, czy prezentacja jest zabezpieczona przed zapisem:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Zweryfikuj lub potwierdź, że użyto określonego hasła**

Możesz chcieć sprawdzić i potwierdzić, że określone hasło zostało użyte do zabezpieczenia dokumentu prezentacji. Aspose.Slides zapewnia możliwość weryfikacji hasła.  

Poniższy przykład kodu pokazuje, jak zweryfikować hasło:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // sprawdź, czy "pass" jest dopasowane do
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Zwraca `true`, jeśli prezentacja została zaszyfrowana przy użyciu podanego hasła. W przeciwnym razie zwraca `false`.  

{{% alert color="primary" title="Zobacz także" %}} 
- [Digital Signature in PowerPoint](/slides/pl/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jakie metody szyfrowania są obsługiwane przez Aspose.Slides?**

Aspose.Slides obsługuje nowoczesne metody szyfrowania, w tym algorytmy oparte na AES, zapewniając wysoki poziom bezpieczeństwa danych twoich prezentacji.

**Co się stanie, jeśli wprowadzisz nieprawidłowe hasło przy próbie otwarcia prezentacji?**

Zostaje zgłoszony wyjątek, jeśli użyto nieprawidłowego hasła, informując, że dostęp do prezentacji został odmówiony. Pomaga to zapobiegać nieautoryzowanemu dostępowi i chroni zawartość prezentacji.

**Czy istnieją jakiekolwiek konsekwencje wydajnościowe przy pracy z prezentacjami zabezpieczonymi hasłem?**

Proces szyfrowania i odszyfrowywania może wprowadzić niewielki narzut podczas operacji otwierania i zapisywania. W większości przypadków wpływ na wydajność jest minimalny i nie wpływa znacząco na całkowity czas przetwarzania zadań związanych z prezentacjami.