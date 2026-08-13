---
title: Zapisz prezentacje w trybie tylko do odczytu w .NET
linktitle: Prezentacja tylko do odczytu
type: docs
weight: 30
url: /pl/net/read-only-presentation/
keywords:
- tylko do odczytu
- zabezpiecz prezentację
- zapobiegaj edycji
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Ładuj i zapisz pliki PowerPoint (PPT, PPTX) w trybie tylko do odczytu przy użyciu Aspose.Slides dla .NET, oferując precyzyjne podglądy slajdów bez modyfikacji Twoich prezentacji."
---
## **Wprowadzenie**

W PowerPoint 2019 firma Microsoft wprowadziła ustawienie **Always Open Read-Only** jako jedną z opcji, które użytkownicy mogą wykorzystać do ochrony swoich prezentacji. Możesz chcieć użyć tego ustawienia **Read-Only**, aby chronić prezentację, gdy

- Chcesz zapobiec przypadkowym edycjom i zachować treść prezentacji w bezpiecznym stanie. 
- Chcesz ostrzec odbiorców, że udostępniona prezentacja jest wersją końcową. 

Po wybraniu opcji **Always Open Read-Only** dla prezentacji, gdy użytkownicy otwierają prezentację, widzą rekomendację **Read-Only** i mogą zobaczyć komunikat w takiej formie: *Aby zapobiec przypadkowym zmianom, autor ustawił ten plik jako otwierany w trybie tylko do odczytu.*

Rekomendacja **Read-Only** jest prostym, ale skutecznym środkiem odstraszającym edycję, ponieważ użytkownicy muszą wykonać czynność, aby ją usunąć, zanim będą mogli edytować prezentację. Jeśli nie chcesz, aby użytkownicy wprowadzali zmiany w prezentacji i chcesz poinformować ich o tym w uprzejmy sposób, rekomendacja **Read-Only** może być dla Ciebie dobrą opcją. 

> Jeśli prezentacja z zabezpieczeniem **Read-Only** zostanie otwarta w starszej aplikacji Microsoft PowerPoint, która nie obsługuje niedawno wprowadzonej funkcji, rekomendacja **Read-Only** zostaje zignorowana (prezentacja jest otwierana normalnie).

## **Zastosuj tryb Read-Only**

Aspose.Slides for .NET umożliwia ustawienie prezentacji jako **Read-Only**, co oznacza, że użytkownicy (po otwarciu prezentacji) widzą rekomendację **Read-Only**. Ten przykładowy kod pokazuje, jak ustawić prezentację jako **Read-Only** w języku C# przy użyciu Aspose.Slides:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 

**Uwaga**: Rekomendacja **Read-Only** ma po prostu na celu zniechęcenie do edycji lub powstrzymanie użytkowników przed przypadkowymi zmianami w prezentacji PowerPoint. Jeśli zmotywowana osoba — która wie, co robi — zdecyduje się edytować Twoją prezentację, może łatwo usunąć ustawienie Read-Only. Jeśli naprawdę potrzebujesz zapobiec nieautoryzowanej edycji, lepiej jest użyć [bardziej rygorystycznych zabezpieczeń obejmujących szyfrowanie i hasła](https://docs.aspose.com/slides/pl/net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

### Czym różni się 'Read-Only recommended' od pełnej ochrony hasłem?

'Read-Only recommended' wyświetla jedynie sugestię otwarcia pliku w trybie tylko do odczytu i łatwo ją obejść. [Password protection](/slides/pl/net/password-protected-presentation/) faktycznie ogranicza otwieranie lub edytowanie i jest odpowiednia, gdy potrzebujesz rzeczywistych kontroli bezpieczeństwa.

### Czy 'Read-Only recommended' można połączyć z znakami wodnymi, aby jeszcze bardziej zniechęcić do edycji?

Tak. Rekomendację można połączyć z [watermarks](/slides/pl/net/watermark/) jako wizualnym środkiem odstraszającym; są to odrębne mechanizmy i dobrze współpracują ze sobą.

### Czy makro lub zewnętrzne narzędzie nadal może modyfikować plik, gdy rekomendacja jest włączona?

Tak. Rekomendacja nie blokuje zmian programistycznych. Aby zapobiec automatycznej edycji, użyj [haseł i szyfrowania](/slides/pl/net/password-protected-presentation/).

### Jak 'Read-Only recommended' odnosi się do flag 'IsEncrypted' i 'IsWriteProtected'?

Są to różne sygnały. 'Read-Only recommended' to miękka, opcjonalna podpowiedź; [IsWriteProtected](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager/iswriteprotected/) i [IsEncrypted](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager/isencrypted/) wskazują rzeczywiste ograniczenia zapisu lub odczytu, które zależą od haseł lub szyfrowania.