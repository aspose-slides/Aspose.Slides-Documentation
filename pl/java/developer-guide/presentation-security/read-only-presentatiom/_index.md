---
title: Zapis prezentacji w trybie tylko do odczytu w Javie
linktitle: Prezentacja tylko do odczytu
type: docs
weight: 30
url: /pl/java/read-only-presentation/
keywords:
- tylko do odczytu
- zabezpiecz prezentację
- zapobiegaj edycji
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Wczytuj i zapisuj pliki PowerPoint (PPT, PPTX) w trybie tylko do odczytu przy użyciu Aspose.Slides for Java, oferując precyzyjne podglądy slajdów bez modyfikowania Twoich prezentacji."
---
## **Wprowadzenie**

W programie PowerPoint 2019 firma Microsoft wprowadziła ustawienie **Always Open Read-Only** jako jedną z opcji, które użytkownicy mogą wykorzystać do zabezpieczenia swoich prezentacji. Możesz chcieć użyć tego ustawienia Tryb tylko do odczytu, aby chronić prezentację, gdy

- Chcesz zapobiec przypadkowym edycjom i zachować zawartość prezentacji w bezpieczeństwie. 
- Chcesz powiadomić odbiorców, że udostępniona przez Ciebie prezentacja jest wersją końcową. 

Po wybraniu opcji **Always Open Read-Only** dla prezentacji, gdy użytkownicy otworzą tę prezentację, zobaczą zalecenie **Read-Only** i mogą zobaczyć komunikat w następującej formie: *Aby zapobiec przypadkowym zmianom, autor ustawił ten plik do otwierania w trybie tylko do odczytu.*

Zalecenie **Read-Only** jest prostym, ale skutecznym środkiem odstraszającym edycję, ponieważ użytkownicy muszą wykonać dodatkowy krok, aby je usunąć, zanim będą mogli edytować prezentację. Jeśli nie chcesz, aby użytkownicy wprowadzali zmiany w prezentacji i chcesz przekazać im to w uprzejmy sposób, zalecenie **Read-Only** może być dla Ciebie dobrą opcją. 

> Jeśli prezentacja z ochroną **Read-Only** zostanie otwarta w starszej wersji programu Microsoft PowerPoint — która nie obsługuje niedawno wprowadzonej funkcji — zalecenie **Read-Only** zostanie zignorowane (prezentacja zostanie otwarta normalnie).

## **Zastosowanie trybu tylko do odczytu**

Aspose.Slides for Java umożliwia ustawienie prezentacji w tryb **Read-Only**, co oznacza, że użytkownicy (po otwarciu prezentacji) widzą zalecenie **Read-Only**. Poniższy przykładowy kod pokazuje, jak ustawić prezentację w tryb **Read-Only** w Javie przy użyciu Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

**Uwaga**: Zalecenie **Read-Only** ma jedynie na celu zniechęcenie do edycji lub powstrzymanie użytkowników przed przypadkowymi zmianami w prezentacji PowerPoint. Jeśli zmotywowana osoba — znająca się na rzeczy — zdecyduje się edytować Twoją prezentację, może łatwo usunąć ustawienie Read-Only. Jeśli naprawdę musisz zapobiec nieautoryzowanej edycji, lepiej jest użyć [bardziej rygorystycznych zabezpieczeń obejmujących szyfrowanie i hasła](https://docs.aspose.com/slides/pl/java/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

### czym różni się „Read-Only recommended” od pełnej ochrony hasłem?

`Read-Only recommended` wyświetla jedynie sugestię otwarcia pliku w trybie tylko do odczytu i łatwo ją obejść. [Ochrona hasłem](/slides/pl/java/password-protected-presentation/) rzeczywiście ogranicza otwieranie lub edycję i jest odpowiednia, gdy potrzebne są rzeczywiste mechanizmy kontroli bezpieczeństwa.

### Czy „Read-Only recommended” można połączyć z znakami wodnymi, aby jeszcze bardziej zniechęcić do edycji?

Tak. Zalecenie można połączyć z [znakami wodnymi](/slides/pl/java/watermark/) jako wizualnym środkiem odstraszającym; są to odrębne mechanizmy i dobrze ze sobą współpracują.

### Czy makro lub zewnętrzne narzędzie może nadal modyfikować plik, gdy zalecenie jest włączone?

Tak. Zalecenie nie blokuje zmian programowych. Aby zapobiec automatycznym edycjom, użyj [haseł i szyfrowania](/slides/pl/java/password-protected-presentation/).

### Jak „Read-Only recommended” odnosi się do metod „isEncrypted” i „isWriteProtected”?

To różne sygnały. `Read-Only recommended` jest miękkim, opcjonalnym podpowiedzeniem; [isWriteProtected](https://reference.aspose.com/slides/pl/java/com.aspose.slides/protectionmanager/#isWriteProtected--) i [isEncrypted](https://reference.aspose.com/slides/pl/java/com.aspose.slides/protectionmanager/#isEncrypted--) wskazują rzeczywiste ograniczenia zapisu lub odczytu zależne od haseł lub szyfrowania.