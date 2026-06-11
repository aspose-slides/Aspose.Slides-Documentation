---
title: Deklaration
type: docs
weight: 110
url: /sv/net/declaration/
keywords:
- deklaration
- komponenter
- Full Trust-behörighet
- registerinställningar
- systemfiler
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig om Aspose.Slides för .NET:s förtroende-krav, behörigheter och värdbegränsningar så att du säkert kan distribuera appar som bearbetar PPT, PPTX och ODP på servrar."
---
{{% alert color="primary" %}} 

Alla Aspose .NET-komponenter kräver behörighetsuppsättningen Full Trust eftersom de ibland måste komma åt registerinställningar, systemfiler och filer som lagras på andra platser (förutom den virtuella katalogen) för vissa operationer (t.ex. teckensnittsanalyser). Dessutom är Aspose .NET Components baserade på .NET:s kärnsystemklasser, vilka i många fall kräver behörighetsuppsättningen Full Trust. 

{{% /alert %}} 

Internetleverantörer, som är värdar för flera applikationer från olika företag, tillämpar i huvudsak säkerhetsnivån Medium Trust. I ett .NET 2.0-fall gäller följande begränsningar för en sådan säkerhetsnivå: 

- OleDbPermission är inte tillgänglig. Det betyder att du inte kan använda ADO.NET:s hanterade OLE DB-dataprovider för att komma åt databaser.
- EventLogPermission är inte tillgänglig. Det betyder att du inte kan komma åt Windows händelseloggen.
- ReflectionPermission är inte tillgänglig. Det betyder att du inte kan använda reflektion.
- RegistryPermission är inte tillgänglig. Det betyder att du inte kan komma åt registret.
- WebPermission är begränsad. Det betyder att din applikation bara kan kommunicera med en adress eller ett adressintervall som du definierade i <trust>-elementet.
- FileIOPermission är begränsad. Det betyder att du bara kan komma åt filer i din applikations virtuella kataloghierarki.

{{% alert color="primary" %}} 

På grund av ovanstående skäl kan Aspose .NET-komponenter endast användas på servrar som beviljar behörighetsuppsättningen Full Trust. 

{{% /alert %}}