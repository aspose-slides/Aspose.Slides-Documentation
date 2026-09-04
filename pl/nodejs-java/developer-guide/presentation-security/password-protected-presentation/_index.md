---
title: Zabezpieczanie prezentacji hasłem w JavaScript
linktitle: Ochrona hasła
type: docs
weight: 20
url: /pl/nodejs-java/password-protected-presentation/
keywords:
- prezentacja zabezpieczona hasłem
- hasło otwierające
- szyfruj PowerPoint
- odszyfruj PowerPoint
- zweryfikuj hasło prezentacji
- sprawdź hasło prezentacji
- otwórz zaszyfrowaną prezentację
- usuń szyfrowanie
- PowerPoint
- PPT
- PPTX
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Szyfruj, wykrywaj, weryfikuj, otwieraj i odszyfruj prezentacje PowerPoint PPT i PPTX zabezpieczone hasłem w JavaScript przy użyciu Aspose.Slides."
---
## **Przegląd**

Hasło otwierające szyfruje prezentację. Prawidłowe hasło jest wymagane do załadowania i wyświetlenia zawartości prezentacji, dzięki czemu ochrona zapewnia poufność.

Hasło otwierające różni się od hasła zabezpieczającego przed zapisem. Zabezpieczenie przed zapisem ogranicza modyfikację, ale nie szyfruje treści ani nie uniemożliwia załadowania prezentacji. Aby zarządzać hasłami umożliwiającymi modyfikację prezentacji, zobacz [Write‑Protect Presentations](/slides/pl/nodejs-java/write-protected-presentation/).

Poniższe scenariusze dotyczą zarówno prezentacji PPT, jak i PPTX. Przykłady używają obu formatów, gdzie istotne jest zachowanie oparte na plikach i strumieniach.

## **Zaszyfruj prezentację hasłem otwierającym**

Użyj [ProtectionManager.encrypt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/protectionmanager/#encrypt), aby przypisać hasło otwierające. Następnie użyj [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save), aby zapisać zaszyfrowaną prezentację.

Poniższy przykład szyfruje prezentację PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Utrzymaj właściwości dokumentu publiczne**

Domyślnie Aspose.Slides uwzględnia właściwości dokumentu w szyfrowaniu prezentacji. Metoda [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) steruje tym zachowaniem niezależnie od szyfrowania treści slajdów. Przed wywołaniem [ProtectionManager.encrypt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/protectionmanager/#encrypt) przekaż `false`, jeśli system indeksowania, klasyfikacji, wyszukiwania lub zarządzania dokumentami musi odczytać metadane bez hasła otwierającego.

Poniższy przykład tworzy zaszyfrowaną prezentację PPTX, pozostawiając wbudowane właściwości dokumentu publiczne:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Przekazanie `false` do [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) nie udostępnia slajdów, szablonów, układów, kształtów, mediów ani innej zawartości prezentacji. Dotyczy wyłącznie właściwości dokumentu. Aby odczytać te właściwości bez ładowania zaszyfrowanej treści, zobacz [Manage Presentation Properties](/slides/pl/nodejs-java/presentation-properties/).

## **Wczytaj zaszyfrowaną prezentację**

Ustaw [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setPassword) na hasło otwierające i przekaż opcje do [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) podczas ładowania pliku. Ładowanie kończy się niepowodzeniem, gdy wymagane jest hasło otwierające, a podane hasło jest brakujące lub nieprawidłowe.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Pracuj z odszyfrowaną prezentacją.
} finally {
    presentation.dispose();
}
```

## **Usuń szyfrowanie z prezentacji**

Wczytaj prezentację z jej hasłem otwierającym, wywołaj [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) i zapisz wynik. Zapisaną prezentację można następnie wczytać bez hasła.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sprawdź hasło otwierające przed wczytaniem**

Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo), aby uzyskać [PresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/) bez tworzenia pełnej instancji prezentacji. Sprawdź [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) przed żądaniem lub weryfikacją hasła. Gdy ochrona jest obecna, zweryfikuj podaną wartość przy pomocy [PresentationInfo.checkPassword](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Przepływ pracy z ścieżką pliku**

Poniższy przykład weryfikuje hasło otwierające dla pliku PPTX, przekazuje zweryfikowaną wartość do [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setPassword), a następnie wczytuje pełną prezentację:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Przepływ pracy ze strumieniem**

Użyj [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream), aby zbadać odczytywalny strumień Node.js. Po zakończeniu inspekcji strumień zostaje zużyty, więc przed wczytaniem pełnej prezentacji utwórz nowy strumień i wywołaj [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

Poniższy przykład używa pliku PPT:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **Wartości zwracane przez checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/#checkPassword) zwraca `true` tylko wtedy, gdy prezentacja posiada hasło otwierające i podane hasło jest prawidłowe. Zwraca `false` w każdym z poniższych przypadków:

- Hasło jest niepoprawne.
- Prezentacja nie ma hasła otwierającego.
- Podane hasło jest `null` lub puste.

Zachowanie jest identyczne dla prezentacji PPT i PPTX.

## **Sprawdź, czy wczytana prezentacja jest szyfrowana**

Po wczytaniu prezentacji z prawidłowym hasłem, sprawdź [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/protectionmanager/#isEncrypted), aby potwierdzić, że źródłowa prezentacja była zaszyfrowana. Aby wykryć ochronę hasłem otwierającym przed wczytaniem, użyj [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) tak, jak pokazano powyżej.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Zalecenia bezpieczeństwa**

{{% alert color="warning" title="Bezpieczeństwo" %}}
Nie loguj haseł otwierających ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych, powtarzających się prób weryfikacji, przechowuj hasła w pamięci tylko tak długo, jak jest to konieczne, i ponownie użyj wyniku udanej weryfikacji przy natychmiastowym ładowaniu prezentacji.

Publiczne właściwości dokumentu mogą ujawniać nazwiska autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze i wartości niestandardowe, nawet gdy treść prezentacji jest zaszyfrowana. Zaszyfruj wrażliwe metadane wraz z prezentacją. Utrzymywanie właściwości publicznych powinno być wyraźną decyzją podjętą tylko wtedy, gdy systemy muszą indeksować, klasyfikować, wyszukiwać lub zarządzać plikiem bez hasła otwierającego.
{{% /alert %}}

## **Zabezpiecz prezentację hasłem online**

1. Otwórz aplikację [Aspose.Slides Lock](https://products.aspose.app/slides/pl/lock).
1. Wybierz lub prześlij prezentację.
1. Wprowadź hasło zabezpieczające podgląd.
1. Opcjonalnie wprowadź oddzielne hasło zabezpieczające edycję.
1. Zastosuj ochronę i pobierz wynikowy plik.

{{% alert color="info" title="Zobacz również" %}}
- [Zabezpiecz prezentacje przed zapisem](/slides/pl/nodejs-java/write-protected-presentation/)
- [Podpis cyfrowy w PowerPoint](/slides/pl/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między hasłem otwierającym a hasłem zabezpieczającym przed zapisem?**

Hasło otwierające szyfruje prezentację i jest wymagane do wczytania jej zawartości. Hasło zabezpieczające przed zapisem ogranicza modyfikację bez szyfrowania treści.

**Czy mogę zweryfikować hasło otwierające bez wczytywania wszystkich slajdów?**

Tak. Pobierz informacje o prezentacji, sprawdź, czy istnieje ochrona hasłem otwierającym, i zweryfikuj hasło przed utworzeniem pełnej instancji prezentacji.

**Czy aplikacja może odczytać metadane bez hasła otwierającego?**

Tak, ale tylko wtedy, gdy prezentacja została zaszyfrowana z wyłączonym szyfrowaniem właściwości dokumentu. Aplikacja musi wtedy użyć trybu ładowania obejmującego wyłącznie właściwości dokumentu, opisanego w [Manage Presentation Properties](/slides/pl/nodejs-java/presentation-properties/).

**Czy scenariusze sprawdzania hasła obsługują zarówno PPT, jak i PPTX?**

Tak. Wykrywanie i weryfikacja hasła oparte na ścieżce pliku oraz na strumieniu działają identycznie dla prezentacji PPT i PPTX.