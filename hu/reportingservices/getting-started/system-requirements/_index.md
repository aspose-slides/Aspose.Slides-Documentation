---
title: Rendszerkövetelmények
type: docs
weight: 15
url: /hu/reportingservices/system-requirements/
keywords:
- rendszerkövetelmények
- SQL Server Reporting Services
- SSRS
- Power BI Jelentéskiszolgáló
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "Ellenőrizze, hogy milyen jelentéskiszolgálókra, kiadásokra és .NET Framework verzióra van szüksége az Aspose.Slides for Reporting Services telepítése előtt."
---
## **Áttekintés**

Az Aspose.Slides for Reporting Services a jelentéskiszolgálóban fut renderelő kiterjesztésként. Ez az oldal felsorolja, hogy milyen előfeltételekre van szükség a jelentéskiszolgáló gépen, mielőtt [install](/slides/hu/reportingservices/installing-aspose-slides-for-reporting-services/) azt. A Microsoft PowerPoint és a Microsoft Office nem szükséges.

## **Támogatott jelentéskiszolgálók**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 and 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server, for paginated (RDL) reports

Mind a 32‑bit, mind a 64‑bit jelentéskiszolgálók támogatottak. A SQL Server 2005 saját verzióját használja a kiterjesztésnek; az összes későbbi verzió és a Power BI Report Server ugyanazt a verziót használja. [Install Manually](/slides/hu/reportingservices/install-manually/) megmutatja, melyik fájlt kell másolni.

Ha a jelentéskiszolgálód verziója nincs ezen a listán, kérdezz a [free support forum](https://forum.aspose.com/c/slides/11) előtt, mielőtt telepítenéd.

## **Jelentéskiszolgáló kiadások**

A SQL Server 2016 Reporting Services és későbbi verziói, valamint a Power BI Report Server esetén a Microsoft támogatja a renderelő kiterjesztéseket az Enterprise, Standard, Developer és Evaluation kiadásokban; a Web és Express kiadások nem támogatják őket. Lásd a [Reporting Services features supported by editions](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server). Az MSI telepítő kihagyja a SQL Server 2016 és korábbi verzióinak Express kiadású példányait.

## **.NET Framework**

A .NET Framework 3.5 telepítve kell legyen a jelentéskiszolgáló gépen. A kiterjesztés összeállításai a .NET Framework 2.0 futtatókörnyezetre lettek építve, és az MSI telepítő üzenettel leáll, ha a .NET Framework 3.5 hiányzik. Windows Serveren adja hozzá a **.NET Framework 3.5 Features** elemet a Szerepkörök és funkciók hozzáadása varázslóban; lásd a [Install .NET Framework 3.5 on Windows](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows).

## **Engedélyek**

A kiterjesztés telepítése módosítja a jelentéskiszolgáló mappájában lévő fájlokat, ezért mindkét telepítési módhoz helyi rendszergazdai jogosultság szükséges. Ha az MSI telepítőt ezek nélkül indítja, felajánlja, hogy újraindul rendszergazdai jogosultsággal.

## **GyIK**

**Szükség van Microsoft PowerPointra a jelentéskiszolgálón?**

Nem. A kiterjesztés maga hozza létre a prezentációkat; sem a PowerPoint, sem a Microsoft Office nem szükséges.

**Telepíthetem a kiterjesztést Express kiadásra?**

Nem. Az Express kiadások nem támogatják a renderelő kiterjesztéseket. Az MSI telepítő elrejti a SQL Server 2016 és korábbi verzióinak Express példányait; a későbbi verziók esetén ne válasszon Express példányt.

**Milyen formátumokat ad a kiterjesztés az exportálási listához?**

PPT, PPS, PPTX, PPSX, ODP és XPS. Lásd a [Supported File Formats](/slides/hu/reportingservices/supported-file-formats/).