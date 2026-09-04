---
title: Zabezpiecz prezentacje hasłem na Androidzie
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/androidjava/password-protected-presentation/
keywords:
- prezentacja zabezpieczona hasłem
- hasło otwierające
- szyfruj PowerPoint
- odszyfruj PowerPoint
- zweryfikuj hasło do prezentacji
- sprawdź hasło prezentacji
- otwórz zaszyfrowaną prezentację
- usuń szyfrowanie
- PowerPoint
- PPT
- PPTX
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Szyfruj, wykrywaj, weryfikuj, otwieraj i odszyfruj prezentacje PowerPoint PPT i PPTX zabezpieczone hasłem przy użyciu Aspose.Slides dla Androida w języku Java."
---
## **Przegląd**

Hasło otwierające szyfruje prezentację. Poprawne hasło jest wymagane do załadowania i wyświetlenia treści prezentacji, więc ta ochrona zapewnia poufność.

Hasło otwierające różni się od hasła ochrony przed zapisem. Ochrona przed zapisem ogranicza modyfikację, ale nie szyfruje treści ani nie uniemożliwia załadowania prezentacji. Aby zarządzać hasłami służącymi do modyfikacji prezentacji, zobacz [Write-Protect Presentations](/slides/pl/androidjava/write-protected-presentation/).

Poniższe przepływy pracy mają zastosowanie zarówno do prezentacji PPT, jak i PPTX. Przykłady używają obu formatów, gdy istotne jest ich zachowanie oparte na pliku i strumieniu.

## **Zaszyfruj prezentację przy użyciu hasła otwierającego**

Użyj [IProtectionManager.encrypt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) aby przypisać hasło otwierające. Następnie użyj [IPresentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-), aby zapisać zaszyfrowaną prezentację.

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

Domyślnie Aspose.Slides uwzględnia właściwości dokumentu w szyfrowaniu prezentacji. Metoda [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) kontroluje to zachowanie niezależnie od szyfrowania zawartości slajdów. Przekaż `false` przed wywołaniem [IProtectionManager.encrypt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-), gdy system indeksowania, klasyfikacji, wyszukiwania lub zarządzania dokumentami musi odczytać metadane bez hasła otwierającego.

Poniższy przykład tworzy zaszyfrowaną prezentację PPTX, pozostawiając wbudowane właściwości dokumentu publiczne:

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

Przekazanie `false` do [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) nie powoduje, że slajdy, mastery, układy, kształty, multimedia ani inna zawartość prezentacji stają się publiczne. Dotyczy to wyłącznie właściwości dokumentu. Aby odczytać te właściwości bez ładowania zaszyfrowanej treści, zobacz [Manage Presentation Properties](/slides/pl/androidjava/presentation-properties/).

## **Załaduj zaszyfrowaną prezentację**

Ustaw [ILoadOptions.setPassword](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) na hasło otwierające i przekaż opcje do [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) podczas ładowania pliku. Ładowanie nie powiedzie się, gdy wymagane jest hasło otwierające, ale podane hasło jest brakujące lub nieprawidłowe.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Pracuj z odszyfrowaną prezentacją.
} finally {
    presentation.dispose();
}
```

## **Usuń szyfrowanie z prezentacji**

Załaduj prezentację z jej hasłem otwierającym, wywołaj [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--), a następnie zapisz wynik. Zapisana prezentacja może być później ładowana bez hasła.

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

## **Sprawdź hasło otwierające przed załadowaniem**

Użyj [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-), aby uzyskać [IPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/) bez tworzenia pełnej instancji prezentacji. Sprawdź [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) przed żądaniem lub weryfikacją hasła. Gdy ochrona jest obecna, zweryfikuj podaną wartość za pomocą [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Przepływ pracy ze ścieżką do pliku**

Poniższy przykład weryfikuje hasło otwierające dla pliku PPTX, przekazuje zweryfikowaną wartość do [ILoadOptions.setPassword](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), a następnie ładuje pełną prezentację:

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

Przeciążenie strumieniowe [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) zapewnia ten sam przepływ pracy. Zresetuj pozycję strumienia umożliwiającego przeszukiwanie przed załadowaniem pełnej prezentacji z tego strumienia.

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

### **Wartości zwracane przez checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) zwraca `true` tylko wtedy, gdy prezentacja posiada hasło otwierające i podane hasło jest poprawne. Zwraca `false` w każdym z następujących przypadków:

- Hasło jest nieprawidłowe.
- Prezentacja nie posiada hasła otwierającego.
- Podane hasło jest `null` lub puste.

Zachowanie jest takie samo dla prezentacji PPT i PPTX.

## **Sprawdź, czy załadowana prezentacja jest zaszyfrowana**

Po załadowaniu prezentacji przy użyciu poprawnego hasła, sprawdź [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) aby potwierdzić, że źródłowa prezentacja była zaszyfrowana. Aby wykryć ochronę hasłem otwierającym przed ładowaniem, użyj `IPresentationInfo.isPasswordProtected` jak pokazano powyżej.

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

## **Zalecenia bezpieczeństwa**

{{% alert color="warning" title="Bezpieczeństwo" %}}
Nie rejestruj haseł otwierających ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych wielokrotnych prób weryfikacji, przechowuj hasła w pamięci tylko tak długo, jak jest to konieczne, i ponownie użyj wyniku pomyślnej weryfikacji przy natychmiastowym ładowaniu prezentacji.

Publiczne właściwości dokumentu mogą ujawniać nazwiska autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze i wartości niestandardowe, mimo że treść prezentacji jest zaszyfrowana. Szyfruj wrażliwe metadane razem z prezentacją. Pozostawienie właściwości publicznych powinno być świadomą decyzją podjętą wyłącznie wtedy, gdy systemy muszą indeksować, klasyfikować, wyszukiwać lub zarządzać plikiem bez hasła otwierającego.
{{% /alert %}}

## **Zabezpiecz prezentację hasłem online**

1. Otwórz aplikację [Aspose.Slides Lock](https://products.aspose.app/slides/pl/lock).
1. Wybierz lub prześlij prezentację.
1. Wprowadź hasło zabezpieczające wyświetlanie.
1. Opcjonalnie wprowadź osobne hasło zabezpieczające edycję.
1. Zastosuj ochronę i pobierz otrzymany plik.

{{% alert color="info" title="Zobacz również" %}}
- [Zabezpiecz prezentacje przed zapisem](/slides/pl/androidjava/write-protected-presentation/)
- [Podpis cyfrowy w PowerPoint](/slides/pl/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**What is the difference between an opening password and a write-protection password?**

Hasło otwierające szyfruje prezentację i jest wymagane do załadowania jej zawartości. Hasło ochrony przed zapisem ogranicza modyfikację bez szyfrowania treści.

**Can I validate an opening password without loading all slides?**

Tak. Uzyskaj informacje o prezentacji, sprawdź, czy istnieje ochrona hasłem otwierającym, i zweryfikuj hasło przed utworzeniem pełnej instancji prezentacji.

**Can an application read metadata without the opening password?**

Tak, ale tylko wtedy, gdy prezentacja została zaszyfrowana z wyłączonym szyfrowaniem właściwości dokumentu. Aplikacja musi wtedy użyć trybu ładowania wyłącznie właściwości dokumentu opisanego w [Manage Presentation Properties](/slides/pl/androidjava/presentation-properties/).

**Do the password-checking workflows support both PPT and PPTX?**

Tak. Wykrywanie i weryfikacja hasła oparte na ścieżce do pliku oraz strumieniu zachowują się tak samo dla prezentacji PPT i PPTX.