---
title: Prohlášení
type: docs
weight: 110
url: /cs/net/declaration/
keywords:
- prohlášení
- komponenty
- oprávnění Full Trust
- nastavení registru
- systémové soubory
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zjistěte informace o požadavcích důvěry, oprávněních a omezeních hostování Aspose.Slides pro .NET, abyste mohli bezpečně nasazovat aplikace zpracovávající PPT, PPTX a ODP na serverech."
---
{{% alert color="info" %}} 

Všechny komponenty Aspose .NET vyžadují nastavení oprávnění Full Trust, protože někdy musí přistupovat k nastavením registru, systémovým souborům a souborům uloženým na jiných místech (kromě virtuálního adresáře) pro určité operace (například parsování fontů). Navíc jsou komponenty Aspose .NET založeny na základních .NET systémových třídách, které v mnoha případech vyžadují nastavení oprávnění Full Trust. 

{{% /alert %}} 

Internetoví poskytovatelé služeb, kteří hostují více aplikací od různých společností, většinou vynucují úroveň zabezpečení Medium Trust. V případě .NET 2.0 tato úroveň zabezpečení ukládá následující omezení: 

- OleDbPermission není k dispozici. To znamená, že nemůžete použít spravovaného poskytovatele dat ADO.NET OLE DB k přístupu k databázím.
- EventLogPermission není k dispozici. To znamená, že nemůžete přistupovat k Windows Event Log.
- ReflectionPermission není k dispozici. To znamená, že nemůžete používat reflexi.
- RegistryPermission není k dispozici. To znamená, že nemůžete přistupovat do registru.
- WebPermission je omezený. To znamená, že vaše aplikace může komunikovat pouze s adresou nebo rozsahem adres, které jste definovali v elementu <trust>.
- FileIOPermission je omezený. To znamená, že můžete přistupovat pouze k souborům ve virtuální adresářové hierarchii vaší aplikace.

{{% alert color="info" %}} 

Z výše uvedených důvodů lze komponenty Aspose .NET používat pouze na serverech, které poskytují nastavení oprávnění Full Trust. 

{{% /alert %}}