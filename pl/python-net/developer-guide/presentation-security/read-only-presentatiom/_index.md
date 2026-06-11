---
title: Zapisz prezentacje w trybie tylko do odczytu przy użyciu Pythona
linktitle: Prezentacja tylko do odczytu
type: docs
weight: 30
url: /pl/python-net/read-only-presentation/
keywords:
- tylko do odczytu
- zabezpiecz prezentację
- zapobiegaj edycji
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Ładuj i zapisuj pliki PowerPoint (PPT, PPTX) w trybie tylko do odczytu przy użyciu Aspose.Slides dla Pythona via .NET, zapewniając precyzyjne podglądy slajdów bez modyfikowania Twoich prezentacji."
---
## **Wprowadzenie**

W programie PowerPoint 2019 firma Microsoft wprowadziła ustawienie **Always Open Read-Only** jako jedną z opcji, które użytkownicy mogą wykorzystać do ochrony swoich prezentacji. Możesz chcieć użyć tego ustawienia Read-Only, aby chronić prezentację, gdy

- Chcesz zapobiec przypadkowym edycjom i zachować treść swojej prezentacji w bezpieczeństwie. 
- Chcesz ostrzec osoby, że dostarczona przez Ciebie prezentacja jest wersją ostateczną. 

Po wybraniu opcji **Always Open Read-Only** dla prezentacji, gdy użytkownicy otworzą prezentację, zobaczą zalecenie **Read-Only** i mogą zobaczyć komunikat w następującej formie: *Aby zapobiec przypadkowym zmianom, autor ustawił ten plik jako otwierany w trybie tylko do odczytu.*

Zalecenie **Read-Only** jest prostym, lecz skutecznym środkiem odstraszającym edycję, ponieważ użytkownicy muszą wykonać czynność, aby je usunąć, zanim będą mogli edytować prezentację. Jeśli nie chcesz, aby użytkownicy wprowadzali zmiany w prezentacji i chcesz poinformować ich o tym w uprzejmy sposób, zalecenie **Read-Only** może być dla Ciebie dobrą opcją. 

> Jeśli prezentacja z ochroną **Read-Only** zostanie otwarta w starszej wersji Microsoft PowerPoint — która nie obsługuje niedawno wprowadzonej funkcji — zalecenie **Read-Only** zostanie zignorowane (prezentacja zostanie otwarta normalnie).

## **Zastosowanie trybu tylko do odczytu**

Aspose.Slides for Python via .NET umożliwia ustawienie prezentacji jako **Read-Only**, co oznacza, że użytkownicy (po otwarciu prezentacji) widzą zalecenie **Read-Only**. Ten przykładowy kod pokazuje, jak ustawić prezentację jako **Read-Only** w języku Python przy użyciu Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**Uwaga**: Zalecenie **Read-Only** ma po prostu na celu zniechęcenie do edycji lub powstrzymanie użytkowników przed przypadkowymi zmianami w prezentacji PowerPoint. Jeśli zmotywowana osoba — która wie, co robi — postanowi edytować Twoją prezentację, może łatwo usunąć ustawienie Read-Only. Jeśli naprawdę musisz zapobiec nieautoryzowanej edycji, lepiej jest używać [bardziej restrykcyjnych zabezpieczeń obejmujących szyfrowanie i hasła](https://docs.aspose.com/slides/pl/python-net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Czym różni się 'Read-Only recommended' od pełnej ochrony hasłem?**

'Read-Only recommended' wyświetla jedynie sugestię otwarcia pliku w trybie tylko do odczytu i jest łatwa do obejścia. [Ochrona hasłem](/slides/pl/python-net/password-protected-presentation/) faktycznie ogranicza otwieranie lub edytowanie i jest odpowiednia, gdy potrzebujesz rzeczywistych kontroli bezpieczeństwa.

**Czy 'Read-Only recommended' można połączyć z znakami wodnymi, aby jeszcze bardziej zniechęcić do edycji?**

Tak. Zalecenie można połączyć z [znakami wodnymi](/slides/pl/python-net/watermark/) jako wizualnym środkiem odstraszającym; są to odrębne mechanizmy i dobrze współpracują.

**Czy makro lub zewnętrzne narzędzie nadal może modyfikować plik, gdy włączone jest zalecenie?**

Tak. Zalecenie nie blokuje zmian programowych. Aby zapobiec automatycznym edycjom, użyj [haseł i szyfrowania](/slides/pl/python-net/password-protected-presentation/).

**Jak 'Read-Only recommended' odnosi się do flag 'is_encrypted' i 'is_write_protected'?**

To różne sygnały. 'Read-Only recommended' jest miękką, opcjonalną sugestią; [is_write_protected](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/is_write_protected/) i [is_encrypted](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/is_encrypted/) wskazują rzeczywiste ograniczenia zapisu lub odczytu, które zależą od haseł lub szyfrowania.