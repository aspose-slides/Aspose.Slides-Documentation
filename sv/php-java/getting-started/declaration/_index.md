---
title: Deklaration
type: docs
weight: 60
url: /sv/php-java/declaration/
keywords:
- deklaration
- komponenter
- Full Trust-behörighet
- registerinställningar
- systemfiler
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Lär dig om Aspose.Slides för PHP:s förtroende-krav, behörigheter och hostingbegränsningar så att du säkert kan distribuera appar som behandlar PPT, PPTX och ODP på servrar."
---
{{% alert color="primary" %}} 

Alla Aspose Java-komponenter kräver Full Trust-behörighetsuppsättning. Anledningen är att Aspose Java-komponenter behöver komma åt registerinställningar, systemfiler utöver den virtuella katalogen för vissa operationer som att parsra teckensnitt osv. Dessutom är Aspose Java-komponenter baserade på kärn‑Java‑systemklasser som också i många fall kräver Full Trust-behörighetsuppsättning. 

{{% /alert %}} 

Internetleverantörer som hostar flera applikationer från olika företag tillämpar oftast säkerhetsnivån Medium Trust: 

- OleDbPermission är inte tillgänglig. Detta betyder att du inte kan använda den hanterade ADO.NET OLE DB-dataleverantören för att komma åt databaser.
- EventLogPermission är inte tillgänglig. Detta betyder att du inte kan komma åt Windows‑händelseloggen.
- ReflectionPermission är inte tillgänglig. Detta betyder att du inte kan använda reflektion.
- RegistryPermission är inte tillgänglig. Detta betyder att du inte kan komma åt registret.
- WebPermission är begränsad. Detta betyder att din applikation bara kan kommunicera med en adress eller ett adressintervall som du definierar i <trust>-elementet.
- FileIOPermission är begränsad. Detta betyder att du bara kan komma åt filer i din applikations virtuella kataloghierarki.

{{% alert color="primary" %}} 

På grund av ovanstående anledningar kan Aspose Java-komponenter inte användas på servrar som beviljar någon annan behörighetsuppsättning än Full Trust. 

{{% /alert %}}