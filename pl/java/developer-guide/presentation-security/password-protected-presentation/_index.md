---
title: Zabezpieczanie prezentacji hasłem w języku Java
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/java/password-protected-presentation/
keywords:
- prezentacja zabezpieczona hasłem
- hasło otwierające
- zaszyfruj PowerPoint
- odszyfruj PowerPoint
- zweryfikuj hasło prezentacji
- sprawdź hasło prezentacji
- otwórz zaszyfrowaną prezentację
- usuń szyfrowanie
- PowerPoint
- PPT
- PPTX
- prezentacja
- Java
- Aspose.Slides
description: "Szyfruj, wykrywaj, weryfikuj, otwieraj i odszyfruj prezentacje PowerPoint PPT i PPTX zabezpieczone hasłem w języku Java przy użyciu Aspose.Slides."
---
## **Przegląd**

Hasło otwierające szyfruje prezentację. Poprawne hasło jest wymagane do wczytania i wyświetlenia zawartości prezentacji, dzięki czemu ochrona zapewnia poufność.

Hasło otwierające różni się od hasła ochrony przed zapisem. Ochrona przed zapisem ogranicza możliwość modyfikacji, ale nie szyfruje treści ani nie uniemożliwia wczytania prezentacji. Aby zarządzać hasłami służącymi do modyfikacji prezentacji, zobacz [Write-Protect Presentations](/slides/pl/java/write-protected-presentation/).

Poniższe przepływy pracy dotyczą zarówno prezentacji PPT, jak i PPTX. Przykłady używają obu formatów, gdy istotne jest ich zachowanie w trybie opartym na pliku oraz strumieniu.

## **Zaszyfruj prezentację przy użyciu hasła otwierającego**

Użyj [IProtectionManager.encrypt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) aby przypisać hasło otwierające. Następnie użyj [IPresentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) aby zapisać zaszyfrowaną prezentację.

Poniższy przykład szyfruje prezentację PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zachowaj właściwości dokumentu publiczne**

Domyślnie Aspose.Slides uwzględnia właściwości dokumentu w szyfrowaniu prezentacji. Metoda [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) steruje tym zachowaniem niezależnie od szyfrowania zawartości slajdów. Przekaż `false` przed wywołaniem [IProtectionManager.encrypt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-), gdy system indeksowania, klasyfikacji, wyszukiwania lub zarządzania dokumentami musi odczytać metadane bez hasła otwierającego.

Poniższy przykład tworzy zaszyfrowaną prezentację PPTX, pozostawiając jej wbudowane właściwości dokumentu publiczne:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Przekazanie `false` do [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) nie udostępnia publicznie slajdów, szablonów, układów, kształtów, multimediów ani innej zawartości prezentacji. Dotyczy to wyłącznie właściwości dokumentu. Aby odczytać te właściwości bez wczytywania zaszyfrowanej zawartości, zobacz [Manage Presentation Properties](/slides/pl/java/presentation-properties/).

## **Wczytaj zaszyfrowaną prezentację**

Ustaw [ILoadOptions.setPassword](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) na hasło otwierające i przekaż opcje do [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) przy wczytywaniu pliku. Wczytywanie nie powiedzie się, gdy wymagane jest hasło otwierające, a podane hasło jest nieobecne lub niepoprawne.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Praca z odszyfrowaną prezentacją.
} finally {
    presentation.dispose();
}
```

## **Usuń szyfrowanie z prezentacji**

Wczytaj prezentację przy użyciu jej hasła otwierającego, wywołaj [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) , a następnie zapisz wynik. Zapisana prezentacja może być później wczytana bez hasła.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sprawdź poprawność hasła otwierającego przed wczytaniem**

Użyj [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) aby uzyskać [IPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/) bez tworzenia pełnej instancji prezentacji. Sprawdź [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) przed żądaniem lub weryfikacją hasła. Gdy ochrona jest obecna, zweryfikuj podaną wartość za pomocą [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Przepływ pracy z ścieżką pliku**

Poniższy przykład weryfikuje hasło otwierające dla pliku PPTX, przekazuje zweryfikowaną wartość do [ILoadOptions.setPassword](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), a następnie wczytuje pełną prezentację:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Przepływ pracy ze strumieniem**

Przeciążenie strumieniowe [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) zapewnia ten sam przepływ pracy. Zresetuj pozycję strumienia umożliwiającego przeszukiwanie przed wczytaniem pełnej prezentacji z tego strumienia.

Poniższy przykład używa pliku PPT:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **checkPassword Return Values**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) zwraca `true` tylko wtedy, gdy prezentacja posiada hasło otwierające i podane hasło jest prawidłowe. Zwraca `false` w każdym z następujących przypadków:

- Hasło jest niepoprawne.
- Prezentacja nie posiada hasła otwierającego.
- Podane hasło jest `null` lub puste.

Zachowanie jest takie samo dla prezentacji PPT i PPTX.

## **Sprawdź, czy wczytana prezentacja jest zaszyfrowana**

Po wczytaniu prezentacji przy użyciu poprawnego hasła, sprawdź [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) aby potwierdzić, że źródłowa prezentacja była zaszyfrowana. Aby wykryć ochronę hasłem otwierającym przed wczytaniem, użyj `IPresentationInfo.isPasswordProtected` jak pokazano powyżej.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Zalecenia dotyczące bezpieczeństwa**

{{% alert color="warning" title="Security" %}}
Nie loguj haseł otwierających ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych, powtarzających się prób weryfikacji, przechowuj hasła w pamięci tylko tak długo, jak jest to potrzebne, i wykorzystuj wynik udanej weryfikacji przy natychmiastowym wczytywaniu prezentacji.

Publiczne właściwości dokumentu mogą ujawniać nazwiska autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze oraz wartości niestandardowe, mimo że zawartość prezentacji jest zaszyfrowana. Szyfruj wrażliwe metadane razem z prezentacją. Pozostawienie właściwości publicznych powinno być świadomą decyzją podjętą tylko wtedy, gdy systemy muszą indeksować, klasyfikować, wyszukiwać lub zarządzać plikiem bez hasła otwierającego.
{{% /alert %}}

## **Zabezpiecz prezentację hasłem online**

1. Otwórz aplikację [Aspose.Slides Lock](https://products.aspose.app/slides/pl/lock).
2. Wybierz lub prześlij prezentację.
3. Wprowadź hasło chroniące podgląd.
4. Opcjonalnie wprowadź osobne hasło chroniące edycję.
5. Zastosuj ochronę i pobierz otrzymany plik.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/pl/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/pl/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica pomiędzy hasłem otwierającym a hasłem ochrony przed zapisem?**

Hasło otwierające szyfruje prezentację i jest wymagane do wczytania jej zawartości. Hasło ochrony przed zapisem ogranicza możliwość modyfikacji bez szyfrowania zawartości.

**Czy mogę zweryfikować hasło otwierające bez wczytywania wszystkich slajdów?**

Tak. Pobierz informacje o prezentacji, sprawdź, czy istnieje ochrona hasłem otwierającym, i zweryfikuj hasło przed utworzeniem pełnej instancji prezentacji.

**Czy aplikacja może odczytać metadane bez hasła otwierającego?**

Tak, ale tylko wtedy, gdy prezentacja została zaszyfrowana z wyłączonym szyfrowaniem właściwości dokumentu. Aplikacja musi wtedy użyć trybu wczytywania jedynie właściwości dokumentu opisanego w [Manage Presentation Properties](/slides/pl/java/presentation-properties/).

**Czy przepływy weryfikacji hasła obsługują zarówno PPT, jak i PPTX?**

Tak. Wykrywanie i weryfikacja hasła oparte na ścieżce pliku oraz strumieniu zachowują się tak samo dla prezentacji PPT i PPTX.