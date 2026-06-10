---
title: Telepítés MSI telepítővel
type: docs
weight: 20
url: /hu/reportingservices/install-with-msi-installer/
---
## **Telepítés**
Az Aspose.Slides for Reporting Services-t MSI telepítővel telepítheti. 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** megköveteli a **.NET Framework 3.5** telepítését a gépen. 

{{% /alert %}}

Futtassa a ***Aspose.Slides.ReportingServices.msi***-t, és kövesse a telepítő által felkínált lépéseket. 

A telepítő másolja az assembly-t és a többi fájlt a megadott könyvtárba, és telepíti a terméket az alapértelmezett Reporting Services példányra. Nem kell manuálisan másolnia vagy módosítania semmilyen fájlt, kivéve ha speciális konfigurációs paramétereket szeretne hozzáadni. 

Az MSI telepítőt használó telepítés a legtöbb esetben a legjobb megoldás. Azonban bizonyos helyzetekben manuálisan is telepítheti a terméket: 

- Az automatikus telepítés biztonsági problémák vagy egyéb okok miatt sikertelen. 
- A terméket egy névvel ellátott (nem alapértelmezett) Reporting Services példányra vagy több példányra kell telepíteni.
- A legújabb verzióra frissítés után csak az assembly cseréjét szeretné ahelyett, hogy az MSI telepítővel eltávolítaná a régi verziót és telepítené az újat. **Megjegyzés** hogy ebben az esetben más fájlok is megmaradhatnak.