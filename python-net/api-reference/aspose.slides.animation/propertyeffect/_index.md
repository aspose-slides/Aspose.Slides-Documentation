---
title: PropertyEffect Class
type: docs
weight: 410
url: /slides/python-net/api-reference/aspose.slides.animation/propertyeffect/
---

Represent property effect behavior.

**Namespace:** [aspose.slides.animation](/slides/python-net/api-reference/aspose.slides.animation/)

**Full Class Name:** aspose.slides.animation.PropertyEffect

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The PropertyEffect type exposes the following members:
## **Constructors**
|**Name**|**Description**|
| :- | :- |
|PropertyEffect()|Initializes a new instance of the PropertyEffect class|
## **Properties**
|**Name**|**Description**|
| :- | :- |
|accumulate|Represents whether animation behaviors are accumulated.<br/>            Read/write [NullableBool](/python-net/api-reference/aspose.slides/nullablebool/).|
|additive|Represents whether the current animation behavior is combined with other running animations.<br/>            Read/write [BehaviorAdditiveType](/python-net/api-reference/aspose.slides.animation/behavioradditivetype/).|
|properties|Represents properties of behavior.<br/>            Read-only [IBehaviorPropertyCollection](/python-net/api-reference/aspose.slides.animation/ibehaviorpropertycollection/).|
|timing|Represents timing properties for the effect behavior.<br/>            Read/write [ITiming](/python-net/api-reference/aspose.slides.animation/itiming/).|
|from_address|Specifies the starting value of the animation.<br/>            Read/write string.|
|to|Specifies the ending value for the animation.<br/>            Read/write string.|
|by|Specifies a relative offset value for the animation with respect to its<br/>            position before the start of the animation.<br/>            Read/write string.|
|value_type|Specifies the type of a property value.<br/>            Read/write [PropertyValueType](/python-net/api-reference/aspose.slides.animation/propertyvaluetype/).|
|calc_mode|Specifies the interpolation mode for the animation<br/>            Read/write [PropertyCalcModeType](/python-net/api-reference/aspose.slides.animation/propertycalcmodetype/).|
|points|Specifies the points of the animation.<br/>            Read/write [IPointCollection](/python-net/api-reference/aspose.slides.animation/ipointcollection/).|
|as_ibehavior|Allows to get base IBehavior interface.<br/>            Read-only [IBehavior](/python-net/api-reference/aspose.slides.animation/ibehavior/).|
