---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides para .NET 14.7.0
linktitle: Aspose.Slides para .NET 14.7.0
type: docs
weight: 90
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legado
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Revise as atualizações da API pública e as alterações que quebram a compatibilidade no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentações PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Esta página lista todas as [adicionadas](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) ou [removidas](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) classes, métodos, propriedades e etc., além de outras alterações introduzidas na API do Aspose.Slides for .NET 14.7.0.

{{% /alert %}} 
## **Alterações da API Pública**
### **Construtores e Elementos Removidos**
#### **Removidos Alguns Construtores de Subtipos de TransitionValueBase e TransitionValueFactory**
Os construtores de alguns subtipos de TransitionValueBase (especificamente CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) são inúteis na API pública e, portanto, foram removidos. 

A classe relacionada TransitionValueFactory e sua interface ITransitionValueFactory foram removidas pelo mesmo motivo.
#### **Removido o Elemento SoundAction da Enumeração Aspose.Slides.SlideShow.TransitionType**
O elemento SoundAction estava incorreto e não era usado. As configurações de som são definidas pelas propriedades SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Classes e Interfaces Adicionadas**
#### **Adicionada a Classe FlyThroughTransition e a Interface IFlyThroughTransition**
A classe Aspose.Slides.SlideShow.FlyThroughTransition (e sua interface Aspose.Slides.SlideShow.IFlyThroughTransition) relaciona‑se ao tipo de transição Flythrough suportado a partir desta versão.
#### **Adicionada a Classe GlitterTransition, a Interface IGlitterTransition e a Enumeração TransitionPattern**
A classe Aspose.Slides.SlideShow.GlitterTransition (e sua interface Aspose.Slides.SlideShow.IGlitterTransition) relaciona‑se ao tipo de transição Glitter suportado a partir desta versão.

A enumeração Aspose.Slides.SlideShow.TransitionPattern é usada nesta classe e especifica um padrão geométrico que se repete para preencher uma área maior.
#### **Adicionada a Classe LeftRightDirectionTransition, a Interface ILeftRightDirectionTransition e a Enumeração TransitionLeftRightDirectionType**
A classe Aspose.Slides.SlideShow.LeftRightDirectionTransition (e sua interface Aspose.Slides.SlideShow.ILeftRightDirectionTransition) relaciona‑se aos tipos de transição Conveyor, Ferris, Flip, Gallery e Switch. Todos são suportados a partir desta versão.

A enumeração Aspose.Slides.SlideShow.TransitionLeftRightDirectionType é usada nesta classe e especifica uma direção, restrita aos valores left e right.
#### **Adicionados Novos Elementos à Enumeração Aspose.Slides.SlideShow.TransitionType**
A enumeração Aspose.Slides.SlideShow.TransitionType foi estendida com novos elementos.

- Novos elementos relacionados às transições do PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Novos elementos relacionados às novas transições do PowerPoint 2013: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Adicionada a Classe RevealTransition e a Interface IRevealTransition**
A classe Aspose.Slides.SlideShow.RevealTransition (e sua interface Aspose.Slides.SlideShow.IRevealTransition) relaciona‑se ao tipo de transição Reveal suportado a partir desta versão.
#### **Adicionada a Classe RippleTransition, a Interface IRippleTransition e a Enumeração TransitionCornerAndCenterDirectionType**
A classe Aspose.Slides.SlideShow.RippleTransition (e sua interface Aspose.Slides.SlideShow.IRippleTransition) relaciona‑se ao tipo de transição Ripple suportado a partir desta versão.

A enumeração Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType é usada nesta classe e especifica uma direção, restrita aos cantos e ao centro.