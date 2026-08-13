---
title: Konfiguracja demo
type: docs
weight: 70
url: /pl/jasperreports/demos-setup/
---
Wszystkie demo dostarczane z Aspose.Slides for JasperReports to zmienione standardowe demo. Lepiej skopiować wszystkie demo do folderu demo JasperReports:
...\jasperreports-x.x.x\demo\samples\

Użyj standardowej kolejności poleceń, aby zbudować i wyeksportować raporty:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="info" %}} 

Proszę nie zapomnieć uruchomić HSQLDB z bazą testową, aby wypełnić raporty danymi i skopiować aspose.slides.jasperreports.library-xx.x.jar z \lib\JasperReports X.X.X - X.X.X folderu w aspose-slides-xx.x-jasperreports.zip do &#60;InstallDir&#62;\lib katalogu.

{{% /alert %}} 

Większość demo (z wyjątkiem Charts) ma już wygenerowane prezentacje, więc możesz pominąć wszystkie kroki "ant" i od razu sprawdzić wyniki.