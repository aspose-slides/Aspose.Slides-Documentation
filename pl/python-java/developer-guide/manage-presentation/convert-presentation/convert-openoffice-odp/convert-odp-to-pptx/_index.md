---
title: Konwertuj ODP do PPTX w Pythonie
linktitle: ODP do PPTX
type: docs
weight: 10
url: /pl/python-java/convert-odp-to-pptx/
keywords:
- konwertuj OpenDocument
- konwertuj prezentację
- konwertuj slajd
- konwertuj ODP
- OpenDocument do PPTX
- ODP do PPTX
- zapisz ODP jako PPTX
- eksportuj ODP do PPTX
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Konwertuj prezentacje ODP do PPTX przy użyciu Aspose.Slides for Python via Java. Użyj pełnego przykładu w Pythonie bez konieczności instalacji PowerPointa ani LibreOffice."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak przekonwertować prezentację OpenDocument (ODP) do formatu PowerPoint (PPTX) przy użyciu Aspose.Slides for Python via Java.

## **Konwersja ODP do PPTX**

Klasa [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) może bezpośrednio wczytać plik ODP. Zapisz wczytaną prezentację w formacie PPTX przy użyciu [SaveFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/).

Postępuj zgodnie z [instrukcje instalacji](/slides/pl/python-java/installation/) przed uruchomieniem przykładu. Umieść prezentację ODP o nazwie `AccessOpenDoc.odp` w katalogu roboczym. Poniższy kod uruchamia JVM w razie potrzeby, otwiera plik ODP i zapisuje go jako `AccessOpenDoc_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessOpenDoc.odp")
try:
    # Zapisz prezentację ODP w formacie PPTX.
    presentation.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Przykład na żywo**

Wypróbuj aplikację webową [Aspose.Slides Conversion](https://products.aspose.app/slides/pl/conversion/), aby zobaczyć konwersję ODP do PPTX napędzaną przez Aspose.Slides.

## **FAQ**

**Czy muszę instalować Microsoft PowerPoint lub LibreOffice, aby konwertować ODP do PPTX?**

Nie. Aspose.Slides for Python via Java odczytuje i zapisuje pliki prezentacji bez potrzeby którejkolwiek z tych aplikacji. Wymagany jest pakiet Python oraz kompatybilne środowisko uruchomieniowe Java.

**Czy master slajdy, układy i motywy są zachowywane podczas konwersji?**

Aspose.Slides mapuje strukturę i formatowanie źródłowej prezentacji na PPTX. Jednak ODP i PPTX obsługują różne funkcje, więc niektóre elementy mogą wyglądać inaczej po konwersji. Udostępnij wymagane czcionki i sprawdź prezentacje o złożonym formatowaniu. Zobacz [konwersja OpenDocument](/slides/pl/python-java/convert-openoffice-odp/) w celu poznania uwag dotyczących kompatybilności.

**Czy mogę konwertować pliki ODP zabezpieczone hasłem?**

Tak, pod warunkiem podania hasła wymaganego do otwarcia pliku. Zobacz [prezentacje zabezpieczone hasłem](/slides/pl/python-java/password-protected-presentation/) po szczegóły dotyczące wczytywania zabezpieczonych plików przed zapisaniem ich w innym formacie.

**Czy Aspose.Slides jest odpowiedni do usług konwersji w chmurze lub opartych na REST?**

Tak. Możesz używać Aspose.Slides for Python via Java w swoim backendzie z wymaganą wersją środowiska uruchomieniowego Java. W przypadku REST API zobacz [Aspose.Slides Cloud](https://products.aspose.cloud/slides/pl/family/).