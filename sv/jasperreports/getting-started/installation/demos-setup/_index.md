---
title: Demoinställning
type: docs
weight: 70
url: /sv/jasperreports/demos-setup/
---
Alla demoexempel som tillhandahålls med Aspose.Slides för JasperReports är ändrade standarddemoexempel. Det är bättre att kopiera alla demoexempel till JasperReports demo‑mappen:
...\jasperreports-x.x.x\demo\samples\

Använd standardkommandosekvensen för att bygga och exportera rapporter:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="primary" %}} 

Vänligen glöm inte att köra HSQLDB med testdatabasen för att fylla rapporterna med data och kopiera aspose.slides.jasperreports.library-xx.x.jar från \lib\JasperReports X.X.X - X.X.X mappen i aspose-slides-xx.x-jasperreports.zip till &#60;InstallDir&#62;\lib katalogen.

{{% /alert %}} 

De flesta demoexempel (förutom Diagram) har redan genererade presentationer så du kan hoppa över alla “ant”-steg och kontrollera resultaten omedelbart.