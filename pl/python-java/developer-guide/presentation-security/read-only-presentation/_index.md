---
title: "Zapisz prezentacje w trybie tylko do odczytu przy użyciu Pythona"
linktitle: "Prezentacja tylko do odczytu"
type: docs
weight: 30
url: /pl/python-java/read-only-presentation/
keywords:
- "tylko do odczytu"
- "zabezpiecz prezentację"
- "zapobiegaj edycji"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "Python"
- "Aspose.Slides"
description: "Ładuj i zapisuj pliki PowerPoint (PPT, PPTX) w trybie tylko do odczytu przy użyciu Aspose.Slides dla Pythona poprzez Java, oferując precyzyjne podglądy slajdów bez modyfikacji prezentacji."
---
## **Wprowadzenie**

W PowerPoint 2019 firma Microsoft wprowadziła opcję **Always Open Read-Only** jako jedną z możliwości, które użytkownicy mogą wykorzystać do zabezpieczania swoich prezentacji. Możesz chcieć użyć tego ustawienia Trybu Tylko do odczytu, aby chronić prezentację, gdy:

- Chcesz zapobiec przypadkowym zmianom i utrzymać zawartość prezentacji w bezpieczeństwie. 
- Chcesz poinformować odbiorców, że dostarczona przez Ciebie prezentacja jest wersją finalną. 

Po wybraniu opcji **Always Open Read-Only** dla prezentacji, gdy użytkownicy otworzą prezentację, zobaczą zalecenie **Read-Only** i mogą zobaczyć komunikat w tej formie: *Aby zapobiec przypadkowym zmianom, autor ustawił ten plik do otwarcia w trybie tylko do odczytu.*

Zalecenie **Read-Only** jest prostym, ale skutecznym środkiem odstraszającym edycję, ponieważ użytkownicy muszą wykonać dodatkowy krok, aby je usunąć, zanim będą mogli edytować prezentację. Jeśli nie chcesz, aby użytkownicy wprowadzali zmiany w prezentacji i chcesz poinformować ich o tym w uprzejmy sposób, zalecenie **Read-Only** może być dla Ciebie dobrą opcją. 

> Jeśli prezentacja z zabezpieczeniem **Read-Only** zostanie otwarta w starszej wersji Microsoft PowerPoint — która nie obsługuje niedawno wprowadzonej funkcji — zalecenie **Read-Only** zostanie zignorowane (prezentacja zostanie otwarta normalnie).

## **Zastosuj tryb tylko do odczytu**

Aspose.Slides for Python via Java umożliwia ustawienie prezentacji jako **Read-Only**, co oznacza, że użytkownicy (po otwarciu prezentacji) widzą zalecenie **Read-Only**. Ten przykład kodu pokazuje, jak ustawić prezentację jako **Read-Only** w Pythonie przy użyciu Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

Zalecenie **Read-Only** ma po prostu na celu odradzenie edycji lub powstrzymanie użytkowników przed wprowadzaniem przypadkowych zmian w prezentacji PowerPoint. Jeśli zmotywowana osoba — która wie, co robi — zdecyduje się edytować Twoją prezentację, może łatwo usunąć ustawienie Read-Only. Jeśli naprawdę musisz zapobiec nieautoryzowanej edycji, lepiej użyć [bardziej rygorystycznych zabezpieczeń obejmujących szyfrowanie i hasła](/slides/pl/python-java/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Czym różni się 'Read-Only recommended' od pełnej ochrony hasłem?**

'Read-Only recommended' wyświetla jedynie sugestię otwarcia pliku w trybie tylko do odczytu i można ją łatwo obejść. [Ochrona hasłem](/slides/pl/python-java/password-protected-presentation/) rzeczywiście ogranicza otwieranie lub edycję i jest odpowiednia, gdy potrzebne są rzeczywiste środki zabezpieczające.

**Czy 'Read-Only recommended' można połączyć z znakami wodnymi, aby jeszcze bardziej zniechęcić do edycji?**

Tak. Zalecenie może być łączone z [znakami wodnymi](/slides/pl/python-java/watermark/) jako wizualnym środkiem odstraszającym; są to odrębne mechanizmy i dobrze ze sobą współpracują.

**Czy makro lub zewnętrzne narzędzie nadal może modyfikować plik, gdy zalecenie jest włączone?**

Tak. Zalecenie nie blokuje zmian programowych. Aby zapobiec automatycznej edycji, użyj [haseł i szyfrowania](/slides/pl/python-java/password-protected-presentation/).

**Jak 'Read-Only recommended' odnosi się do metod [isEncrypted](https://reference.aspose.com/slides/pl/python-java/aspose.slides/protectionmanager/#isEncrypted) i [isWriteProtected](https://reference.aspose.com/slides/pl/python-java/aspose.slides/protectionmanager/#isWriteProtected)?**

Są to różne sygnały. 'Read-Only recommended' to miękka, opcjonalna sugestia; [isWriteProtected](https://reference.aspose.com/slides/pl/python-java/aspose.slides/protectionmanager/#isWriteProtected) i [isEncrypted](https://reference.aspose.com/slides/pl/python-java/aspose.slides/protectionmanager/#isEncrypted) wskazują rzeczywiste ograniczenia zapisu lub odczytu, które zależą od haseł lub szyfrowania.