---
title: Rendszerkövetelmények
type: docs
weight: 60
url: /hu/jasperreports/system-requirements/
description: "Ellenőrizze, hogy az Aspose.Slides for JasperReports mely JasperReports és Java verziókkal működik, és mire van szüksége Linuxon."
---
## **JasperReports**

Aspose.Slides for JasperReports a JasperReports 3.7.2 és 6.16.0 közötti verziókkal működik. A letöltés három verziócsoporthoz külön jar-fájlt tartalmaz - lásd a [Installing Aspose.Slides for JasperReports](/slides/hu/jasperreports/installing-aspose-slides-for-jasperreports/) oldalon, hogy melyiket kell használni. Nem tartalmaz jar-fájlt a JasperReports 6.17.0 vagy újabb verzióihoz, beleértve a JasperReports 7-ét.

A JasperReports 2.0.3-tól 3.7.1-ig terjedő verziók támogatása befejeződött az Aspose.Slides for JasperReports 17.6-ban. A 17.5-ös és korábbi verziók szintén támogatták ezeket a verziókat.

## **Java**

A jar-fájlok Java 6 vagy újabb verzióra vannak fordítva, ahogy a mappanevekben szereplő *JDK 1.6* is mutatja, ezért a szükséges Java-verzió megegyezik a JasperReports verziójához szükséges verzióval. A JasperReports 6.16.0 esetén az exportálás Java 11, 17, 21 és 25 verziókon fut.

## **Operating system**

A jar-fájlok csak Java-osztályokat és erőforrásokat tartalmaznak, nincsenek bennük natív könyvtárak, és nem használnak Microsoft PowerPoint-ot. Linuxon a JasperReports-nek fontconfig-ra és legalább egy telepített betűtípusra van szüksége a jelentés kitöltéséhez.

## **JasperReports Server**

A JasperReports Server esetén használja mindkét jar-fájlt annak a mappának a tartalmából, amely megfelel a szerver által futtatott JasperReports verziónak - lásd a [Integration with JasperServer](/slides/hu/jasperreports/integration-with-jasperserver/) oldalt.