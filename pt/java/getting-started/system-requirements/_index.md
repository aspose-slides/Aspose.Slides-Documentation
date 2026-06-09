---
title: Requisitos do Sistema
type: docs
weight: 80
url: /pt/java/system-requirements/
keywords:
- requisitos do sistema
- sistema operacional
- instalação
- dependências
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Descubra os requisitos do sistema do Aspose.Slides for Java. Garanta suporte perfeito a PowerPoint e OpenDocument no Windows, Linux e macOS."
---
## **Visão geral**
O Aspose.Slides for Java não necessita do Microsoft PowerPoint instalado, pois o próprio Aspose.Slides é um mecanismo de criação, conversão, layout de página e renderização de documentos Microsoft PowerPoint.

## **Sistemas Operacionais compatíveis**
O Aspose.Slides for Java suporta qualquer sistema operacional de 32 bits ou 64 bits que execute o runtime Java, incluindo, mas não se limitando a:

### **Windows**
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2008 Server ( x64, x86)
- Microsoft Windows 2012 Server ( x64, x86)
- Microsoft Windows 2012 R2 Server ( x64, x86)
- Microsoft Windows 2016 Server ( x64, x86)
- Microsoft Windows 2019 Server ( x64, x86)
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)

### **Linux**
- Linux (Ubuntu, OpenSUSE, CentOS e outros)

### **Mac**
- Mac OS X

## **Versões Java compatíveis**
O Aspose.Slides for Java suporta J2SE 6.0 (Java 1.6) e superiores.

## **Perguntas frequentes**
**Preciso do Microsoft PowerPoint instalado para conversões e renderização?**

Não, o PowerPoint não é necessário; o Aspose.Slides é um mecanismo independente para [criar](/slides/pt/java/create-presentation/), modificar, [converter](/slides/pt/java/convert-presentation/) e [renderizar](/slides/pt/java/convert-powerpoint-to-png/) apresentações.

**Quais fontes são necessárias para renderização correta?**

Na prática, as fontes usadas na apresentação ou [substitutos](/slides/pt/java/font-substitution/) adequados devem estar disponíveis. Para garantir renderização consistente em Linux/macOS, recomenda-se instalar pacotes de fontes comuns.

**Por que uma fonte personalizada é renderizada como substituta ou texto ausente no Linux?**

Se o arquivo de fonte contém entradas da tabela de nomes inconsistentes ou corrompidas, a pilha de correspondência de fontes do Linux (FreeType/fontconfig) pode selecionar um registro inválido, fazendo com que a fonte não seja resolvida. Utilizar uma versão da fonte com registros de tabela de nomes corrigidos ou instalar uma substituição consistente resolve o problema.