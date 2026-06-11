---
title: Zapis prezentacji w trybie tylko do odczytu w .NET
linktitle: Prezentacja tylko do odczytu
type: docs
weight: 30
url: /pl/net/read-only-presentation/
keywords:
- tylko do odczytu
- ochrona prezentacji
- zapobieganie edycji
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Wczytuj i zapisuj pliki PowerPoint (PPT, PPTX) w trybie tylko do odczytu przy użyciu Aspose.Slides for .NET, zapewniając precyzyjne podglądy slajdów bez zmieniania prezentacji."
---
## **Wprowadzenie**

W PowerPoint 2019 firma Microsoft wprowadziła ustawienie **Always Open Read-Only** jako jedną z opcji, które użytkownicy mogą wykorzystać do ochrony swoich prezentacji. Możesz chcieć użyć tego ustawienia tylko do odczytu, aby chronić prezentację, gdy

- chcesz zapobiec przypadkowym edycjom i zabezpieczyć treść prezentacji,
- chcesz poinformować odbiorców, że dostarczona prezentacja jest wersją ostateczną.

Po wybraniu opcji **Always Open Read-Only** dla prezentacji, gdy użytkownicy otwierają plik, widzą zalecenie **Read-Only** i mogą zobaczyć komunikat w takiej formie: *Aby zapobiec przypadkowym zmianom, autor ustawił ten plik do otwierania w trybie tylko do odczytu.*

Zalecenie **Read-Only** jest prostym, a jednocześnie skutecznym środkiem odstraszającym od edycji, ponieważ użytkownicy muszą wykonać dodatkowy krok, aby je usunąć przed edycją prezentacji. Jeśli nie chcesz, aby użytkownicy wprowadzali zmiany w prezentacji i chcesz poinformować ich o tym w uprzejmy sposób, zalecenie **Read-Only** może być dla Ciebie dobrą opcją.

> Jeśli prezentacja z ochroną **Read-Only** zostanie otwarta w starszej wersji Microsoft PowerPoint — która nie obsługuje wprowadzonej niedawno funkcji — zalecenie **Read-Only** zostanie zignorowane (prezentacja zostanie otwarta normalnie).

## **Zastosowanie trybu tylko do odczytu**

Aspose.Slides for .NET umożliwia ustawienie prezentacji jako **Read-Only**, co oznacza, że użytkownicy (po otwarciu prezentacji) widzą zalecenie **Read-Only**. Ten przykładowy kod pokazuje, jak ustawić prezentację jako **Read-Only** w C# przy użyciu Aspose.Slides:

```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

**Uwaga**: Zalecenie **Read-Only** ma na celu jedynie zniechęcenie do edycji lub zapobieżenie przypadkowym zmianom w prezentacji PowerPoint. Jeśli zmotywowana osoba — znająca się na rzeczy — zdecyduje się edytować Twoją prezentację, może łatwo usunąć ustawienie tylko do odczytu. Jeśli naprawdę potrzebujesz zapobiec nieautoryzowanej edycji, lepiej użyć [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/pl/net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Czym różni się „Read-Only recommended” od pełnej ochrony hasłem?**

„Read-Only recommended” wyświetla jedynie sugestię otwarcia pliku w trybie tylko do odczytu i jest łatwe do pominięcia. [Password protection](/slides/pl/net/password-protected-presentation/) faktycznie ogranicza otwieranie lub edycję i jest odpowiednie, gdy potrzebujesz rzeczywistych kontroli zabezpieczeń.

**Czy „Read-Only recommended” można połączyć z znakami wodnymi, aby jeszcze bardziej zniechęcić do edycji?**

Tak. Zalecenie można połączyć z [watermarks](/slides/pl/net/watermark/) jako wizualnym środkiem odstraszającym; są to odrębne mechanizmy i dobrze współpracują.

**Czy makro lub zewnętrzne narzędzie mogą nadal modyfikować plik, gdy włączone jest zalecenie?**

Tak. Zalecenie nie blokuje zmian programistycznych. Aby zapobiec automatycznym edycjom, użyj [passwords and encryption](/slides/pl/net/password-protected-presentation/).

**Jak „Read-Only recommended” odnosi się do flag „IsEncrypted” i „IsWriteProtected”?**

To różne sygnały. „Read-Only recommended” jest miękkim, opcjonalnym komunikatem; [IsWriteProtected](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager/iswriteprotected/) i [IsEncrypted](https://reference.aspose.com/slides/pl/net/aspose.slides/protectionmanager/isencrypted/) wskazują rzeczywiste ograniczenia zapisu lub odczytu, które zależą od haseł lub szyfrowania.