---
title: Zabezpieczanie prezentacji hasłem na Androidzie
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/androidjava/password-protected-presentation/
keywords:
- blokowanie PowerPoint
- blokowanie prezentacji
- odblokowywanie PowerPoint
- odblokowywanie prezentacji
- ochrona PowerPoint
- ochrona prezentacji
- ustaw hasło
- dodaj hasło
- szyfrowanie PowerPoint
- szyfrowanie prezentacji
- odszyfrowywanie PowerPoint
- odszyfrowywanie prezentacji
- ochrona przed zapisem
- bezpieczeństwo PowerPoint
- bezpieczeństwo prezentacji
- usuwanie hasła
- usuwanie ochrony
- usuwanie szyfrowania
- wyłączanie hasła
- wyłączanie ochrony
- usuwanie ochrony przed zapisem
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Bezproblemowo blokuj i odblokowuj prezentacje PowerPoint oraz OpenDocument chronione hasłem przy użyciu Aspose.Slides dla Androida w Java. Zabezpiecz swoje prezentacje."
---
## **Wprowadzenie**

Kiedy zabezpieczasz prezentację hasłem, oznacza to ustawienie hasła, które narzuca określone ograniczenia na prezentację. Aby usunąć ograniczenia, należy wprowadzić hasło. Prezentacja zabezpieczona hasłem jest uważana za zablokowaną prezentację.

Typowo możesz ustawić hasło, aby wymusić te ograniczenia na prezentacji:

- **Modyfikacja**

  Jeśli chcesz, aby tylko określeni użytkownicy mogli modyfikować Twoją prezentację, możesz ustawić ograniczenie modyfikacji. To ograniczenie zapobiega osobom modyfikowanie, zmienianie lub kopiowanie elementów w Twojej prezentacji (chyba że podadzą hasło). 

  Jednak w tym przypadku, nawet bez hasła, użytkownik będzie mógł uzyskać dostęp do dokumentu i go otworzyć. W trybie tylko do odczytu użytkownik może przeglądać zawartość, taką jak hiperlinki, animacje, efekty i inne elementy w prezentacji, ale nie może kopiować elementów ani zapisywać prezentacji. 

- **Otwieranie**

  Jeśli chcesz, aby tylko określeni użytkownicy mogli otwierać Twoją prezentację, możesz ustawić ograniczenie otwierania. To ograniczenie uniemożliwia osobom nawet przeglądanie zawartości prezentacji (chyba że podadzą hasło).

  Technicznie ograniczenie otwierania również uniemożliwia użytkownikom modyfikację prezentacji: gdy osoby nie mogą otworzyć prezentacji, nie mogą jej modyfikować ani wprowadzać zmian. 
  
  **Uwaga** że kiedy zabezpieczasz prezentację hasłem, aby uniemożliwić otwieranie, plik prezentacji zostaje zaszyfrowany.

## **Ochrona hasłem prezentacji w Aspose.Slides**
**Obsługiwane formaty**

Aspose.Slides obsługuje ochronę hasłem, szyfrowanie i podobne operacje dla prezentacji w następujących formatach: 

- PPTX and PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP -  OpenDocument Presentation Template 

**Obsługiwane operacje**

Aspose.Slides pozwala używać ochrony hasłem w prezentacjach, aby zapobiegać modyfikacjom w następujący sposób:

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

Możesz zaszyfrować prezentację, ustawiając hasło. Następnie, aby modyfikować zablokowaną prezentację, użytkownik musi podać hasło. 

Aby zaszyfrować lub zabezpieczyć prezentację hasłem, musisz użyć metody encrypt (z [IProtectionManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IProtectionManager)) aby ustawić hasło dla prezentacji. Przekazujesz hasło do metody encrypt i używasz metody save, aby zapisać teraz zaszyfrowaną prezentację.

Ten przykładowy kod pokazuje, jak zaszyfrować prezentację:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ustawienie ochrony przed zapisem w prezentacji**

Możesz dodać do prezentacji znak „Do not modify”. W ten sposób informujesz użytkowników, że nie chcesz, aby wprowadzali zmiany w prezentacji.  

**Uwaga** że proces ochrony przed zapisem nie szyfruje prezentacji. Dlatego użytkownicy—jeśli naprawdę tego chcą—mogą modyfikować prezentację, ale aby zapisać zmiany, będą musieli utworzyć prezentację pod inną nazwą. 

Aby ustawić ochronę przed zapisem, musisz użyć metody [setWriteProtection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Ten przykładowy kod pokazuje, jak ustawić ochronę przed zapisem w prezentacji:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Wczytywanie zaszyfrowanej prezentacji**

Aspose.Slides pozwala wczytać zaszyfrowaną prezentację, przekazując prawidłowe hasło za pomocą [LoadOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/).

Ten przykładowy kod pokazuje, jak otworzyć zaszyfrowaną prezentację: 

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // praca z odszyfrowaną prezentacją
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Usuwanie szyfrowania z prezentacji**

Możesz usunąć szyfrowanie lub ochronę hasłem w prezentacji. W ten sposób użytkownicy będą mogli uzyskać dostęp lub modyfikować prezentację bez ograniczeń. 

Aby usunąć szyfrowanie lub ochronę hasłem, musisz wywołać metodę [removeEncryption](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) . Ten przykładowy kod pokazuje, jak usunąć szyfrowanie z prezentacji:

```java
import com.aspose.slides.*;

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

Możesz użyć Aspose.Slides do usunięcia ochrony przed zapisem zastosowanej w pliku prezentacji. W ten sposób użytkownicy mogą modyfikować według własnego uznania — i nie otrzymują ostrzeżeń przy wykonywaniu takich operacji.

Możesz usunąć ochronę przed zapisem z prezentacji, używając metody [removeWriteProtection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Ten przykładowy kod pokazuje, jak usunąć ochronę przed zapisem z prezentacji:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Pobieranie właściwości zaszyfrowanej prezentacji**

Zazwyczaj użytkownicy mają trudności z pobraniem właściwości dokumentu zaszyfrowanej lub chronionej hasłem prezentacji. Jednak Aspose.Slides oferuje mechanizm, który pozwala zabezpieczyć prezentację hasłem, jednocześnie zachowując możliwość dostępu do jej właściwości przez użytkowników.

**Uwaga:** Domyślnie, gdy Aspose.Slides szyfruje prezentację, właściwości dokumentu prezentacji również są chronione hasłem. Jeśli potrzebujesz, aby właściwości dokumentu były dostępne nawet po szyfrowaniu, Aspose.Slides umożliwia dokładnie to.

Jeśli chcesz, aby użytkownicy zachowali możliwość dostępu do właściwości zaszyfrowanej prezentacji, przekaż `false` do [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Ten przykładowy kod pokazuje, jak zaszyfrować prezentację, jednocześnie udostępniając użytkownikom dostęp do jej właściwości dokumentu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Wczytywanie tylko właściwości dokumentu z zaszyfrowanej prezentacji**

Aby sprawdzić metadane zaszyfrowanej prezentacji bez wczytywania jej slajdów lub innej zawartości, utwórz obiekt [LoadOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/) i przekaż `true` do [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). W tym trybie Aspose.Slides ignoruje hasło i wczytuje tylko właściwości dokumentu, które są publicznie dostępne.

Poniższy przykład kodu odczytuje wbudowane i niestandardowe właściwości dokumentu przy użyciu [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Odczyt wbudowanych właściwości dokumentu.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Odczyt niestandardowych właściwości dokumentu.
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

Ten przepływ pracy działa tylko wtedy, gdy właściwości dokumentu pozostały niezaszyfrowane (publiczne) podczas szyfrowania prezentacji. Jeśli właściwości dokumentu są zaszyfrowane, przekazanie `true` do `loadOptions.setOnlyLoadDocumentProperties` powoduje wyjątek, ponieważ w tym trybie hasło jest ignorowane. Aby uzyskać dostęp do zaszyfrowanych właściwości dokumentu lub wczytać pełną prezentację, łącznie ze slajdami i inną zawartością, podaj prawidłowe hasło za pomocą [ILoadOptions.setPassword](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Sprawdzanie, czy prezentacja jest zabezpieczona hasłem**

Przed wczytaniem prezentacji możesz chcieć sprawdzić i potwierdzić, że prezentacja nie została zabezpieczona hasłem. W ten sposób unikasz błędów i podobnych problemów, które pojawiają się, gdy zabezpieczona hasłem prezentacja jest wczytywana bez podania hasła.

Ten kod Java pokazuje, jak zbadać prezentację, aby sprawdzić, czy jest zabezpieczona hasłem (bez wczytywania samej prezentacji):

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Sprawdzanie, czy prezentacja jest zaszyfrowana**

Aspose.Slides pozwala sprawdzić, czy prezentacja jest zaszyfrowana. Aby wykonać to zadanie, możesz użyć właściwości [isEncrypted](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) , która zwraca `true`, jeśli prezentacja jest zaszyfrowana, lub `false`, jeśli nie jest zaszyfrowana.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest zaszyfrowana:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Sprawdzanie, czy prezentacja jest chroniona przed zapisem**

Aspose.Slides pozwala sprawdzić, czy prezentacja jest chroniona przed zapisem. Aby wykonać to zadanie, możesz użyć właściwości [isWriteProtected](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) , która zwraca `true`, jeśli prezentacja jest chroniona przed zapisem, lub `false`, jeśli nie jest.

Ten przykładowy kod pokazuje, jak sprawdzić, czy prezentacja jest chroniona przed zapisem:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Walidacja lub potwierdzenie, że użyto konkretnego hasła**

Możesz chcieć sprawdzić i potwierdzić, że konkretne hasło zostało użyte do zabezpieczenia dokumentu prezentacji. Aspose.Slides zapewnia możliwość walidacji hasła. 

Ten przykładowy kod pokazuje, jak zwalidować hasło:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // sprawdź, czy "pass" jest dopasowane do
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Zwraca `true`, jeśli prezentacja została chroniona przed zapisem podanym hasłem. W przeciwnym razie zwraca `false`. 

{{% alert color="info" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/pl/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jakie metody szyfrowania są obsługiwane przez Aspose.Slides?**

Aspose.Slides obsługuje nowoczesne metody szyfrowania, w tym algorytmy oparte na AES, zapewniając wysoki poziom bezpieczeństwa danych w Twoich prezentacjach.

**Co się dzieje, gdy wprowadzono nieprawidłowe hasło przy próbie otwarcia prezentacji?**

Jeśli użyto nieprawidłowego hasła, zostaje rzucony wyjątek, informując, że dostęp do prezentacji jest odrzucony. Pomaga to zapobiegać nieautoryzowanemu dostępowi i chroni zawartość prezentacji.

**Czy istnieją jakiekolwiek konsekwencje wydajnościowe przy pracy z prezentacjami zabezpieczonymi hasłem?**

Proces szyfrowania i odszyfrowywania może wprowadzić niewielki narzut podczas operacji otwierania i zapisywania. W większości przypadków wpływ na wydajność jest minimalny i nie wpływa znacząco na całkowity czas przetwarzania zadań związanych z prezentacją.