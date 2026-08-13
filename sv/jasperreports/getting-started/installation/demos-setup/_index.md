---
title: Inställning av demonstrationer
type: docs
weight: 70
url: /sv/jasperreports/demos-setup/
---
Alla demonstrationer som levereras med Aspose.Slides för JasperReports är modifierade standarddemonstrationer. Det är bättre att kopiera alla demonstrationer till JasperReports demo‑mapp:
...\jasperreports-x.x.x\demo\samples\

Använd standardkommandosekvensen för att bygga och exportera rapporter:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="info" %}} 

Glöm inte att köra HSQLDB med testdatabasen för att fylla rapporterna med data och kopiera aspose.slides.jasperreports.library-xx.x.jar från \lib\JasperReports X.X.X - X.X.X‑mappen i aspose-slides-xx.x-jasperreports.zip till &#60;InstallDir&#62;\lib‑katalogen.

{{% /alert %}} 

De flesta demonstrationer (förutom Charts) har redan genererade presentationer så du kan hoppa över alla “ant”-steg och kontrollera resultaten omedelbart.