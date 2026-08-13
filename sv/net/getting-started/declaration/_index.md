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
description: "Läs om Aspose.Slides för .NET:s förtroendekrav, behörigheter och värdbegränsningar så att du säkert kan distribuera appar som bearbetar PPT, PPTX och ODP på servrar."
---
{{% alert color="info" %}} 

Alla Aspose .NET‑komponenter kräver Full Trust‑behörighetsuppsättningen eftersom de ibland måste komma åt registerinställningar, systemfiler och filer som lagras på andra platser (förutom den virtuella katalogen) för vissa operationer (t.ex. parsning av typsnitt). Dessutom är Aspose .NET‑komponenter baserade på kärn‑.NET‑systemklasser, som i många fall kräver Full Trust‑behörighetsuppsättningen. 

{{% /alert %}} 

Internetleverantörer, som är värdar för flera applikationer från olika företag, använder oftast säkerhetsnivån Medium Trust. I ett .NET 2.0‑fall innebär en sådan säkerhetsnivå följande begränsningar: 

- OleDbPermission är inte tillgänglig. Detta betyder att du inte kan använda ADO.NET:s hanterade OLE DB-dataleverantör för att komma åt databaser.
- EventLogPermission är inte tillgänglig. Detta betyder att du inte kan komma åt Windows händelselogg.
- ReflectionPermission är inte tillgänglig. Detta betyder att du inte kan använda reflektion.
- RegistryPermission är inte tillgänglig. Detta betyder att du inte kan komma åt registret.
- WebPermission är begränsad. Detta betyder att din applikation bara kan kommunicera med en adress eller ett adressintervall som du definierat i <trust>-elementet.
- FileIOPermission är begränsad. Detta betyder att du bara kan komma åt filer i din applikations virtuella kataloghierarki.

{{% alert color="info" %}} 

På grund av ovanstående skäl kan Aspose .NET‑komponenter endast användas på servrar som beviljar Full Trust‑behörighetsuppsättningen. 

{{% /alert %}}