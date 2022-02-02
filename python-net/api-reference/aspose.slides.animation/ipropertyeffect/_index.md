---
title: IPropertyEffect Class
type: docs
weight: 270
url: /python-net/api-reference/aspose.slides.animation/ipropertyeffect/
---

Represent property effect behavior.

**Namespace:** [aspose.slides.animation](/slides/python-net/api-reference/aspose.slides.animation/)

**Full Class Name:** aspose.slides.animation.IPropertyEffect



The IPropertyEffect type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|from_address|Specifies the starting value of the animation.<br/>            Read/write string.|
|to|Specifies the ending value for the animation.<br/>            Read/write string.|
|by|Specifies a relative offset value for the animation with respect to its<br/>            position before the start of the animation.<br/>            Read/write string.|
|value_type|Specifies the type of a property value.<br/>            Read/write [PropertyValueType](/slides/python-net/api-reference/aspose.slides.animation/propertyvaluetype/).|
|calc_mode|Specifies the interpolation mode for the animation<br/>            Read/write [PropertyCalcModeType](/slides/python-net/api-reference/aspose.slides.animation/propertycalcmodetype/).|
|points|Specifies the points of the animation.<br/>            Read/write [IPointCollection](/slides/python-net/api-reference/aspose.slides.animation/ipointcollection/).|
|as_ibehavior|Allows to get base IBehavior interface.<br/>            Read-only [IBehavior](/slides/python-net/api-reference/aspose.slides.animation/ibehavior/).|
|accumulate|Represents whether animation behaviors are accumulated.<br/>            Read/write [NullableBool](/slides/python-net/api-reference/aspose.slides/nullablebool/).|
|additive|Represents whether the current animation behavior is combined with other running animations.<br/>            Read/write [BehaviorAdditiveType](/slides/python-net/api-reference/aspose.slides.animation/behavioradditivetype/).|
|properties|Represents properties of behavior.<br/>            Read-only [IBehaviorPropertyCollection](/slides/python-net/api-reference/aspose.slides.animation/ibehaviorpropertycollection/).|
|timing|Represents timing properties for the effect behavior.<br/>            Read/write [ITiming](/slides/python-net/api-reference/aspose.slides.animation/itiming/).|
