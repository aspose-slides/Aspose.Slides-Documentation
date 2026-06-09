---
title: Requisitos do Sistema
type: docs
weight: 60
url: /pt/php-java/system-requirements/
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
- PHP
- Aspose.Slides
description: "Descubra os requisitos do sistema do Aspose.Slides for PHP via Java. Garanta suporte perfeito a PowerPoint e OpenDocument no Windows, Linux e macOS."
---
## **Introdução**

O Aspose.Slides for PHP via Java não requer nenhum produto de terceiros, como o Microsoft PowerPoint, instalado. O próprio Aspose.Slides é um mecanismo para criar, modificar, converter e renderizar documentos em vários formatos, incluindo formatos de apresentação do Microsoft PowerPoint.

## **Sistemas Operacionais Suportados**

Aspose.Slides for Java suporta qualquer sistema operacional de 32‑bit ou 64‑bit que execute o runtime Java, incluindo, mas não se limitando a:

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

## **Perguntas Frequentes**

**Preciso do Microsoft PowerPoint instalado para conversões e renderização?**

Não, o PowerPoint não é necessário; o Aspose.Slides é um mecanismo autônomo para [criar](/slides/pt/php-java/create-presentation/), modificar, [converter](/slides/pt/php-java/convert-presentation/) e [renderizar](/slides/pt/php-java/convert-powerpoint-to-png/) apresentações.

**Quais fontes são necessárias para renderização correta?**

Na prática, as fontes usadas na apresentação ou [substitutos](/slides/pt/php-java/font-substitution/) adequados devem estar disponíveis. Para garantir renderização consistente em Linux/macOS, recomenda‑se instalar pacotes de fontes comuns.

**Por que uma fonte personalizada é renderizada como fallback ou texto ausente no Linux?**

Se o arquivo de fonte contiver entradas de tabela de nomes inconsistentes ou corrompidas, a pilha de correspondência de fontes do Linux (FreeType/fontconfig) pode selecionar um registro inválido, fazendo com que a fonte não seja resolvida. Utilizar uma versão da fonte com registros de tabela de nomes corrigidos ou instalar um substituto consistente resolve o problema.