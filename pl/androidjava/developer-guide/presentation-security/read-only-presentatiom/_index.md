---
title: Zapisz prezentacje w trybie tylko do odczytu na Androidzie
linktitle: Prezentacja tylko do odczytu
type: docs
weight: 30
url: /pl/androidjava/read-only-presentation/
keywords:
- tylko do odczytu
- ochrona prezentacji
- zapobieganie edycji
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Zapisz pliki PowerPoint (PPT, PPTX) w trybie tylko do odczytu przy użyciu Aspose.Slides for Android via Java, oferując precyzyjne podglądy slajdów bez zmieniania Twoich prezentacji."
---
## **Wprowadzenie**

W programie PowerPoint 2019 firma Microsoft wprowadziła ustawienie **Always Open Read-Only** jako jedną z opcji, których użytkownicy mogą używać do ochrony swoich prezentacji. Możesz chcieć skorzystać z tego ustawienia tylko do odczytu, aby chronić prezentację, gdy

- chcesz zapobiec przypadkowym edycjom i zabezpieczyć zawartość prezentacji,
- chcesz poinformować odbiorców, że dostarczona prezentacja jest wersją końcową.

Po wybraniu opcji **Always Open Read-Only** dla prezentacji, gdy użytkownicy otworzą plik, zobaczą rekomendację **Read-Only** i mogą otrzymać komunikat w tej postaci: *Aby zapobiec przypadkowym zmianom, autor ustawił ten plik do otwierania w trybie tylko do odczytu.*

Rekomendacja **Read-Only** jest prostym, a jednocześnie skutecznym środkiem odstraszającym edycję, ponieważ użytkownicy muszą wykonać dodatkowy krok, aby ją usunąć przed edycją prezentacji. Jeśli nie chcesz, aby użytkownicy wprowadzali zmiany w prezentacji i chcesz przekazać im tę informację w uprzejmy sposób, rekomendacja **Read-Only** może być dla Ciebie dobrą opcją.

> Jeśli prezentacja z ochroną **Read-Only** zostanie otwarta w starszej wersji Microsoft PowerPoint, która nie obsługuje wprowadzonej funkcji, rekomendacja **Read-Only** zostanie zignorowana (prezentacja zostanie otwarta normalnie).

## **Zastosuj tryb tylko do odczytu**

Aspose.Slides for Android via Java umożliwia ustawienie prezentacji jako **Read-Only**, co oznacza, że użytkownicy (po otwarciu prezentacji) zobaczą rekomendację **Read-Only**. Poniższy fragment kodu pokazuje, jak w języku Java przy użyciu Aspose.Slides ustawić prezentację w tryb **Read-Only**:

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
**Uwaga**: Rekomendacja **Read-Only** ma na celu jedynie zniechęcenie do edycji lub powstrzymanie przypadkowych zmian w prezentacji PowerPoint. Jeśli zmotywowana osoba, która wie, co robi, zdecyduje się edytować Twoją prezentację, może łatwo usunąć ustawienie tylko do odczytu. Jeśli naprawdę musisz zapobiec nieautoryzowanej edycji, lepiej użyć [bardziej rygorystycznych ochron, które obejmują szyfrowanie i hasła](https://docs.aspose.com/slides/pl/androidjava/password-protected-presentation/).
{{% /alert %}} 

## **FAQ**

### Jak „Read-Only recommended” różni się od pełnej ochrony hasłem?

„Read-Only recommended” wyświetla jedynie sugestię otwarcia pliku w trybie tylko do odczytu i łatwo ją obejść. [Ochrona hasłem](/slides/pl/androidjava/password-protected-presentation/) faktycznie ogranicza otwieranie lub edycję i jest odpowiednia, gdy potrzebujesz prawdziwych zabezpieczeń.

### Czy „Read-Only recommended” można połączyć z znakami wodnymi, aby jeszcze bardziej zniechęcić do edycji?

Tak. Rekomendację można połączyć z [znakami wodnymi](/slides/pl/androidjava/watermark/) jako wizualnym środkiem odstraszającym; są to odrębne mechanizmy, które dobrze ze sobą współpracują.

### Czy makro lub zewnętrzne narzędzie nadal mogą modyfikować plik, gdy włączona jest rekomendacja?

Tak. Rekomendacja nie blokuje zmian programistycznych. Aby zapobiec automatycznej edycji, użyj [haseł i szyfrowania](/slides/pl/androidjava/password-protected-presentation/).

### Jak „Read-Only recommended” odnosi się do metod „isEncrypted” i „isWriteProtected”?

Są to różne sygnały. „Read-Only recommended” to miękka, opcjonalna podpowiedź; [isWriteProtected](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) i [isEncrypted](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) wskazują rzeczywiste ograniczenia zapisu lub odczytu, które zależą od haseł lub szyfrowania.