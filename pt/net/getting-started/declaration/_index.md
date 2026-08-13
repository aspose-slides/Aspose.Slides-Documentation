---
title: Declaração
type: docs
weight: 110
url: /pt/net/declaration/
keywords:
- declaração
- componentes
- permissão Full Trust
- configurações de registro
- arquivos de sistema
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda sobre os requisitos de confiança, permissões e limitações de hospedagem do Aspose.Slides para .NET, para que você possa implantar aplicativos que processam PPT, PPTX e ODP em servidores com segurança."
---
{{% alert color="info" %}} 

Todos os componentes Aspose .NET requerem o conjunto de permissões Full Trust porque às vezes precisam acessar configurações do registro, arquivos de sistema e arquivos armazenados em outros locais (além do diretório virtual) para certas operações (como analisar fontes, por exemplo). Além disso, os Componentes Aspose .NET são baseados nas classes principais do sistema .NET, que exigem o conjunto de permissões Full Trust em muitos casos. 

{{% /alert %}} 

Os provedores de serviços de Internet, que hospedam múltiplas aplicações de diferentes empresas, geralmente aplicam o nível de segurança Medium Trust. No caso do .NET 2.0, esse nível de segurança impõe as seguintes restrições: 

- OleDbPermission não está disponível. Isso significa que você não pode usar o provedor de dados OLE DB gerenciado pelo ADO.NET para acessar bancos de dados.
- EventLogPermission não está disponível. Isso significa que você não pode acessar o log de eventos do Windows.
- ReflectionPermission não está disponível. Isso significa que você não pode usar reflexão.
- RegistryPermission não está disponível. Isso significa que você não pode acessar o registro.
- WebPermission é restrito. Isso significa que sua aplicação só pode se comunicar com um endereço ou intervalo de endereços que você definiu no elemento <trust>.
- FileIOPermission é restrito. Isso significa que você só pode acessar arquivos na hierarquia de diretórios virtuais da sua aplicação.

{{% alert color="info" %}} 

Devido aos motivos acima, os componentes Aspose .NET só podem ser usados em servidores que concedem o conjunto de permissões Full Trust. 

{{% /alert %}}