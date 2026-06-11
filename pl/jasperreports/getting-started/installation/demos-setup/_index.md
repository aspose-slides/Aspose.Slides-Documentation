---
title: Konfiguracja demonstracji
type: docs
weight: 70
url: /pl/jasperreports/demos-setup/
---
Wszystkie demonstracje dostarczane z Aspose.Slides for JasperReports to zmodyfikowane standardowe demonstracje. Lepiej skopiować wszystkie demonstracje do folderu demonstracji JasperReports:
...\jasperreports-x.x.x\demo\samples\

Użyj standardowej sekwencji poleceń, aby zbudować i wyeksportować raporty:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="primary" %}} 
Proszę nie zapomnieć uruchomić HSQLDB z bazą testową, aby wypełnić raporty danymi i skopiować aspose.slides.jasperreports.library-xx.x.jar z folderu \lib\JasperReports X.X.X - X.X.X w archiwum aspose-slides-xx.x-jasperreports.zip do katalogu &#60;InstallDir&#62;\lib.
{{% /alert %}} 

Większość demonstracji (z wyjątkiem Charts) ma już wygenerowane prezentacje, więc możesz pominąć wszystkie kroki „ant” i od razu sprawdzić wyniki.